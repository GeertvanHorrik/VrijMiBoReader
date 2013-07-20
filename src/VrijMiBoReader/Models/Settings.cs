// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Models
{
    using Catel.Data;

    public class Settings : SavableModelBase<Settings>, ISettings
    {
        public bool ShowYoutube { get; set; }

        public bool ShowMusic { get; set; }
    }
}