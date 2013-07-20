// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutWindow.xaml.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader.Views
{
    using Catel.Windows;

    using VrijMiBoReader.ViewModels;

    /// <summary>
    /// Interaction logic for AboutWindow.xaml.
    /// </summary>
    public partial class AboutWindow : DataWindow
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow"/> class.
        /// </summary>
        public AboutWindow()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow"/> class.
        /// </summary>
        /// <param name="viewModel">
        /// The view model to inject.
        /// </param>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public AboutWindow(AboutViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
        #endregion
    }
}