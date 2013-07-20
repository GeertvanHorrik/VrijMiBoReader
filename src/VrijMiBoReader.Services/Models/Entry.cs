// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entry.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Models
{
    using System;
    using System.Collections.ObjectModel;

    using Catel.Data;

    public class Entry : ModelBase, IEntry
    {
        public Entry()
        {
            Items = new ObservableCollection<IEntryItem>();
        }

        #region IEntry Members
        public int UniqueIdentifier { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public bool HasItems 
        { 
            get { return Items.Count > 0; } 
        }

        public ObservableCollection<IEntryItem> Items { get; private set; }
        #endregion
    }
}