// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryViewModel.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.ViewModels
{
    using System.Collections.ObjectModel;

    using Catel;
    using Catel.MVVM;
    using Catel.MVVM.Services;

    using VrijMiBoReader.Models;
    using VrijMiBoReader.Services;

    public class EntryViewModel : ViewModelBase
    {
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly ICrawlerService _crawlerService;
        private readonly IProcessService _processService;
        private readonly ISettings _settings;

        public EntryViewModel(IEntry entry, IPleaseWaitService pleaseWaitService, ICrawlerService crawlerService, IProcessService processService, 
            ISettings settings)
        {
            Argument.IsNotNull(() => entry);
            Argument.IsNotNull(() => pleaseWaitService);
            Argument.IsNotNull(() => crawlerService);
            Argument.IsNotNull(() => processService);
            Argument.IsNotNull(() => settings);

            Entry = entry;
            _pleaseWaitService = pleaseWaitService;
            _crawlerService = crawlerService;
            _processService = processService;
            _settings = settings;

            OpenInBrowser = new Command(OnOpenInBrowserExecute, OnOpenInBrowserCanExecute);
        }

        [Model]
        public IEntry Entry { get; private set; }

        [ViewModelToModel("Entry")]
        public ObservableCollection<IEntryItem> Items { get; private set; }

        protected override void Initialize()
        {
            if (Items.Count == 0)
            {
                _pleaseWaitService.Show(() =>
                    {
                        _crawlerService.GetEntryDetails(Entry);
                    }, "Loading the data for the selected entry...");
            }
        }

        #region Commands
        /// <summary>
        /// Gets the OpenInBrowser command.
        /// </summary>
        public Command OpenInBrowser { get; private set; }

        /// <summary>
        /// Method to check whether the OpenInBrowser command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnOpenInBrowserCanExecute()
        {
            if (Items == null)
            {
                return false;
            }

            if (Items.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to invoke when the OpenInBrowser command is executed.
        /// </summary>
        private void OnOpenInBrowserExecute()
        {
            foreach (var entryItem in Items)
            {
                bool openItem = true;

                switch (entryItem.EntryItemType)
                {
                    case EntryItemType.Music:
                        openItem = _settings.ShowMusic;
                        break;

                    case EntryItemType.Youtube:
                        openItem = _settings.ShowYoutube;
                        break;

                    case EntryItemType.Unknown:
                        openItem = true;
                        break;

                    default:
                        openItem = true;
                        break;
                }

                if (openItem)
                {
                    _processService.StartProcess(entryItem.Url);
                }
            }
        }
        #endregion
    }
}