// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsViewModel.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.ViewModels
{
    using Catel;
    using Catel.MVVM;

    using VrijMiBoReader.Models;

    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(ISettings settings)
        {
            Argument.IsNotNull(() => settings);

            Settings = settings;
        }

        [Model]
        [Expose("ShowYoutube")]
        [Expose("ShowMusic")]
        public ISettings Settings { get; private set; }
    }
}