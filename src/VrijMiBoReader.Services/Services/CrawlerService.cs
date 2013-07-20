// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrawlerService.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Catel;
    using Catel.Collections;
    using Catel.Logging;

    using VrijMiBoReader.Cache;
    using VrijMiBoReader.Models;

    public class CrawlerService : ICrawlerService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly IEntryCache _entryCache;

        private readonly IParserService _parserService;

        public CrawlerService(IEntryCache entryCache, IParserService parserService)
        {
            Argument.IsNotNull(() => entryCache);
            Argument.IsNotNull(() => parserService);

            _entryCache = entryCache;
            _parserService = parserService;
        }

        public IEnumerable<IEntry> ListAllAvailableEntries()
        {
            var lastCheckedDate = Constants.PatternStartDate;
            var indexCounter = Constants.PatternStartIndex;

            var lastItem = (from item in _entryCache.GetEntries()
                            orderby item.Date descending
                            select item).FirstOrDefault();

            if (lastItem != null)
            {
                lastCheckedDate = lastItem.Date;
                indexCounter = lastItem.UniqueIdentifier;
            }

            var resultsFromRequest = new List<IEntry>();

            // Loop all fridays
            var failedUrls = new List<string>();
            var tomorrow = DateTime.Now.AddDays(1);
            while (lastCheckedDate <= tomorrow)
            {
                lastCheckedDate = lastCheckedDate.AddDays(7);
                var foundEntry = TryToFetchEntry(lastCheckedDate, indexCounter, failedUrls);
                if (foundEntry != null)
                {
                    resultsFromRequest.Add(foundEntry);
                    indexCounter++;
                }
            }

            foreach (var resultFromRequest in resultsFromRequest)
            {
                _entryCache.Add(resultFromRequest);
            }

            return (from entry in _entryCache.GetEntries()
                    orderby entry.Date descending
                    select entry);
        }

        public IEnumerable<IEntryItem> GetEntryDetails(IEntry entry)
        {
            Argument.IsNotNull(() => entry);

            if (entry.Items.Count > 0)
            {
                return entry.Items;
            }

            string url = entry.Url;

            try
            {
                Log.Debug("Trying to fetch entry items from '{0}'", url);

                var webClient = new WebClient();
                var pageContent = webClient.DownloadString(url);

                var entryItems = _parserService.ParseEntryItems(entry, pageContent);
                entry.Items.ReplaceRange(entryItems);

                return entry.Items;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to get VrijMiBo entries from '{0}'", url);

                return new List<IEntryItem>();
            }
        }

        private IEntry TryToFetchEntry(DateTime date, int indexCounter, List<string> failedUrls)
        {
            var url = VrijMiBoHelper.GetUrl(date, indexCounter);
            if (failedUrls.Contains(url))
            {
                return null;
            }

            try
            {
                Log.Debug("Trying to fetch entry from '{0}'", url);

                var webRequest = WebRequest.Create(url);
                webRequest.Method = "HEAD";
                using (var webResponse = webRequest.GetResponse())
                {
                }

                Log.Info("Found a valid entry at url '{0}'", url);

                return new Entry
                {
                    Date = date,
                    UniqueIdentifier = indexCounter,
                    Url = url,
                    Name = VrijMiBoHelper.GetName(date, indexCounter)
                };
            }
            catch (Exception ex)
            {
                failedUrls.Add(url);

                Log.Warning(ex, "Failed to get VrijMiBo for date '{0}' and index '{1}'", date, indexCounter);

                return null;
            }
        }
    }
}