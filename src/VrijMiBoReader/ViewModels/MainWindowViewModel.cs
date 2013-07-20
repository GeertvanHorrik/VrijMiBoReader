// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.ViewModels
{
    using System.Collections.ObjectModel;

    using Catel;
    using Catel.Collections;
    using Catel.MVVM;
    using Catel.MVVM.Services;

    using VrijMiBoReader.Cache;
    using VrijMiBoReader.Models;
    using VrijMiBoReader.Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ICrawlerService _crawlerService;

        private readonly IPleaseWaitService _pleaseWaitService;

        #region Constructors
        public MainWindowViewModel(ISettings settings, ICrawlerService crawlerService, IPleaseWaitService pleaseWaitService)
            : base()
        {
            Argument.IsNotNull(() => settings);
            Argument.IsNotNull(() => crawlerService);
            Argument.IsNotNull(() => pleaseWaitService);

            _crawlerService = crawlerService;
            _pleaseWaitService = pleaseWaitService;

            Settings = settings;

            AvailableEntries = new ObservableCollection<IEntry>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public override string Title
        {
            get
            {
                return "VrijMiBo Reader";
            }
        }

        public ObservableCollection<IEntry> AvailableEntries { get; private set; }

        public IEntry SelectedEntry { get; set; }

        public ISettings Settings { get; private set; }
        #endregion

        #region Commands
        #endregion

        #region Methods
        protected override void Initialize()
        {
            _pleaseWaitService.Show(() =>
            {
                var entries = _crawlerService.ListAllAvailableEntries();

                AvailableEntries.ReplaceRange(entries);

                SelectedEntry = AvailableEntries.Count > 0 ? AvailableEntries[0] : null;
            }, "Checking for new entries...");
        }
        #endregion
    }
}