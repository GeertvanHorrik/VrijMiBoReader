// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrawlerService.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Services
{
    using System.Collections.Generic;

    using VrijMiBoReader.Models;

    public interface ICrawlerService
    {
        #region Methods
        IEnumerable<IEntry> ListAllAvailableEntries();

        IEnumerable<IEntryItem> GetEntryDetails(IEntry entry);
        #endregion
    }
}