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
        }

        private void DescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedPokemon = PMViewModel.SelectedPokemon;
            Frame.Navigate(typeof(Description), SelectedPokemon);
        }
    }
}
