using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using FinalApp.ViewModels;
using PokemonTcgSdk.Models;

namespace FinalApp
{
    public sealed partial class Description : Page
    {
        public PokemonViewModel PMViewModel { get; set; }
        public PokemonCard SelectedCard;

        public Description()
        {
            this.InitializeComponent();
            this.PMViewModel = new PokemonViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is PokemonCard && e.Parameter != null)
            {
                SelectedCard = (PokemonCard)e.Parameter;
            }
            base.OnNavigatedTo(e);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += About_BackRequested;

            AbilityTextBox.Text = AbilityString();
            AttackTextBox.Text = AttackString();
        }

        public string AttackString()
        {
            string attackString = "Attacks: \n";
            if (SelectedCard.Attacks[0] != null)
            {
                for (int i = 0; i < SelectedCard.Attacks.Count(); i++)
                {
                    attackString += "\n" + (i + 1).ToString() + " - " + SelectedCard.Attacks[i].Name + "\n" + SelectedCard.Attacks[i].Text;
                }
            }
            return attackString;
        }

        public string AbilityString()
        {
            string abilityString = "Abilities: ";
            if (SelectedCard.Ability != null)
            {
                abilityString += SelectedCard.Ability.Name + " - " + SelectedCard.Ability.Text;
            }

            return abilityString;
        }

        private void About_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            e.Handled = true;
        }
    }
}
