// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntryCache.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Cache
{
    using System.Collections.Generic;

    using VrijMiBoReader.Models;

    public interface IEntryCache
    {
        #region Methods
        void Clear();

        void Add(IEntry entry);

        void Save();
        #endregion

        IEnumerable<IEntry> GetEntries();
    }
}