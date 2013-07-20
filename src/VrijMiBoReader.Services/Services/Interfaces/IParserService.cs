// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParserService.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Services
{
    using System.Collections.Generic;

    using VrijMiBoReader.Models;

    public interface IParserService
    {
        #region Methods
        List<IEntryItem> ParseEntryItems(IEntry entry, string pageContent);

        EntryItemType GetEntryItemType(string url);
        #endregion
    }
}