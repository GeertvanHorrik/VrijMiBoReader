// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserService.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Services
{
    using System.Collections.Generic;

    using Catel;
    using Catel.Logging;

    using VrijMiBoReader.Models;

    public class ParserService : IParserService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public List<IEntryItem> ParseEntryItems(IEntry entry, string pageContent)
        {
            Argument.IsNotNull(() => entry);
            Argument.IsNotNullOrWhitespace(() => pageContent);

            const string StartText = "<article id=\"";
            const string EndText = "</article>";

            var entryItems = new List<IEntryItem>();

            int firstIndex = pageContent.IndexOf(StartText);
            if (firstIndex == -1)
            {
                Log.Warning("Failed to find start of article, cannot return entry items for url '{0}'", entry.Url);
                return entryItems;
            }

            var lastIndex = pageContent.IndexOf(EndText, firstIndex);
            if (lastIndex == -1)
            {
                Log.Warning("Failed to find end of article, probably returning way too many entries for url '{0}'", entry.Url);
            }

            string subPageContent = pageContent.Substring(firstIndex, lastIndex - firstIndex);

            // Parse all href elements
            int currentIndex = 0;
            while (currentIndex < lastIndex)
            {
                int newIndex;
                string linkUrl = GetUrlFromPage(subPageContent, currentIndex, out newIndex);
                if (linkUrl == null)
                {
                    Log.Debug("No urls found, we probably parsed all links");
                    break;
                }

                if (!linkUrl.ToLower().Contains(entry.Url.ToLower()))
                {
                    Log.Debug("Found link '{0}'", linkUrl);

                    entryItems.Add(new EntryItem
                    {
                        Url = linkUrl,
                        EntryItemType = GetEntryItemType(linkUrl)
                    });
                }

                currentIndex = newIndex + 1;
            }

            return entryItems;
        }

        public EntryItemType GetEntryItemType(string url)
        {
            Argument.IsNotNullOrWhitespace(() => url);

            if (url.Contains("youtube"))
            {
                return EntryItemType.Youtube;
            }

            if (url.Contains("soundcloud"))
            {
                return EntryItemType.Music;
            }

            return EntryItemType.Unknown;
        }

        private string GetUrlFromPage(string pageContent, int index, out int lastIndex)
        {
            const string HrefStart = "href=\"";
            const string HrefEnd = "\"";

            lastIndex = -1;

            int linkStart = pageContent.IndexOf("<a ", index);
            if (linkStart == -1)
            {
                return null;
            }

            lastIndex = linkStart;

            int hrefStart = pageContent.IndexOf(HrefStart, linkStart);
            if (hrefStart != -1)
            {
                hrefStart += HrefStart.Length;
                int hrefEnd = pageContent.IndexOf(HrefEnd, hrefStart);

                return pageContent.Substring(hrefStart, hrefEnd - hrefStart);
            }

            return null;
        }
    }
}