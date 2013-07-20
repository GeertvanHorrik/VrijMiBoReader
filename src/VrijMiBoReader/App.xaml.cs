// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader
{
    using System.Windows;

    using Catel.IoC;
    using Catel.Windows;

    using VrijMiBoReader.Cache;
    using VrijMiBoReader.Models;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        #region Methods
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.
        /// </param>
        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            Catel.Logging.LogManager.RegisterDebugListener();
#endif

            StyleHelper.CreateStyleForwardersForDefaultStyles();

            var serviceLocator = ServiceLocator.Default;

            // TODO: Load settings from disk
            serviceLocator.RegisterInstance<ISettings>(new Settings());

            // TODO: Load cache from disk
            var cache = new EntryCache();
            serviceLocator.RegisterInstance<IEntryCache>(cache);

            base.OnStartup(e);
        }
        #endregion
    }
}