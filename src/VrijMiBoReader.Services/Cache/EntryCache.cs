// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryCache.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Cache
{
    using System;
    using System.Collections.Generic;

    using VrijMiBoReader.Models;

    public class EntryCache : IEntryCache
    {
        private readonly List<IEntry> _entries = new List<IEntry>(); 

        #region Constructors
        public EntryCache()
        {
            LoadFromCache();
        }
        #endregion

        #region IEntryCache Members
        public IEnumerable<IEntry> GetEntries()
        {
            return _entries;
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public void Add(IEntry entry)
        {
            _entries.Add(entry);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods
        private void LoadFromCache()
        {
            // TODO: Implement
        }
        #endregion
    }
}