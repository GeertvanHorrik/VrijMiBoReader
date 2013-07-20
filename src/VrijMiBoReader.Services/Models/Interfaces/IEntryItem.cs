// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntryItem.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Models
{
    public enum EntryItemType
    {
        Music,

        Youtube,

        Unknown
    }

    public interface IEntryItem
    {
        string Url { get; set; }

        EntryItemType EntryItemType { get; set; }
    }
}