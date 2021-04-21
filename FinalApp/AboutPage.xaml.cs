using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FinalApp
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();
            AboutInformation();
        }
        /// <summary>
        /// Controls for back button
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Display back button
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;

            //Call About_BackRequested function to navigate to Main Page
            SystemNavigationManager.GetForCurrentView().BackRequested += About_BackRequested;
        }

        /// <summary>
        /// return to MainPage from About Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            e.Handled = true;
        }
        /// <summary>
        /// Displaying information about the app such as the authors
        /// </summary>
        private void AboutInformation()
        {
            Package package = Package.Current;

            appTitle.Text = $"Name: {package.DisplayName}";
            appVersion.Text = $"Version: {package.Id.Version.Major}.{package.Id.Version.Minor}.{package.Id.Version.Build}";
            appPublisher.Text = $"Publisher: {package.PublisherDisplayName}";
            appGroupMembers.Text = "Group Members: Cole Rhyno-Wiedemann, Kingsly Cooper, Max Muir, Aaron Thomas";
        }
    }
}
