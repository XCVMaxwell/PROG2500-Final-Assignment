using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using FinalApp.ViewModels;
using PokemonTcgSdk.Models;

namespace FinalApp
{
    public sealed partial class MainPage : Page
    {
        public PokemonViewModel PMViewModel { get; set; }
        public PokemonCard SelectedPokemon { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.PMViewModel = new PokemonViewModel();
            PMViewModel.ImageChanged += PMViewModel_ImageChanged;
        }

        // Using event because setting source on image element didn't work.
        private void PMViewModel_ImageChanged(object sender, EventArgs e)
        {
            try
            {
                PokemonImage.Source = new BitmapImage(new Uri(PMViewModel.PokemonImage));
            }
            catch (UriFormatException ex) {}
        }

        private void DescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedPokemon = PMViewModel.SelectedPokemon;
            Frame.Navigate(typeof(Description), SelectedPokemon);
        }
    }
}
