// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntry.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Models
{
    using System;
    using System.Collections.ObjectModel;

    public interface IEntry
    {
        #region Properties
        int UniqueIdentifier { get; set; }

        string Url { get; set; }

        string Name { get; set; }

        bool HasItems { get; }

        ObservableCollection<IEntryItem> Items { get; }

        DateTime Date { get; set; }
        #endregion
    }
}