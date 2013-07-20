// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISettings.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Models
{
    public interface ISettings
    {
        #region Properties
        bool ShowYoutube { get; set; }

        bool ShowMusic { get; set; }
        #endregion
    }
}