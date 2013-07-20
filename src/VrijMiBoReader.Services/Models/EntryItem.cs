// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryItem.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Models
{
    using Catel.Data;

    public class EntryItem : ModelBase, IEntryItem
    {
        #region Properties
        public string Url { get; set; }

        public EntryItemType EntryItemType { get; set; }
        #endregion
    }
}