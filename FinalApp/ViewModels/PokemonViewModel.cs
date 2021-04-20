﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PokemonTcgSdk.Models;

namespace FinalApp.ViewModels
{
    public class PokemonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ImageChanged;

        public ObservableCollection<PokemonCard> Pokemons { get; set; }
        private List<PokemonCard> _allPokemon = new List<PokemonCard>();

        public string PokemonNumber { get; set; }
        public string PokemonHP { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string PokemonSubType { get; set; }
        public string PokemonAbility { get; set; }
        public string PokemonAbilityDesc { get; set; }
        public string PokemonAttack { get; set; }
        public string PokemonAttackDesc { get; set; }
        public string PokemonImage { get; set; }

        public bool IsPokemonSelected { get; set; } = false;
        private PokemonCard _selectedPokemon;
        private string _filter;

        public PokemonViewModel()
        {
            _allPokemon = GetAllPokemon();
            Pokemons = new ObservableCollection<PokemonCard>();

            PerformFiltering();
        }

        public List<PokemonCard> GetAllPokemon()
        {
            return Repos.PokemonRepo.GetAllPokemonCards();
        }

        public PokemonCard SelectedPokemon
        {
            get { return _selectedPokemon; }
            set
            {
                _selectedPokemon = value;

                if (value == null)
                {
                    PokemonNumber = "";
                    PokemonHP = "";
                    PokemonName = "No Pokemon selected";
                    PokemonType = "";
                    PokemonImage = "";

                    IsPokemonSelected = false;
                }
                else
                {
                    var type = value.Types != null ? value.Types[0] : "No Types";

                    PokemonNumber = "Number: " + value.NationalPokedexNumber;
                    PokemonName = "Name: " + value.Name;
                    PokemonHP = "HP: " + value.Hp;
                    PokemonType = "Type: " + type;
                    PokemonSubType = value.SubType;
                    if (value.Ability != null) 
                    {
                        PokemonAbility = value.Ability.ToString();
                    }
                    if (value.Attacks != null)
                    {
                        PokemonAttack = value.Attacks[0].ToString();
                    }
                    PokemonImage = value.ImageUrlHiRes;

                    IsPokemonSelected = true;
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonNumber"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonName"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonHP"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonType"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonSubType"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonAbility"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonAttack"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PokemonImage"));
                ImageChanged?.Invoke(this, null);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPokemonSelected"));
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter) { return; }
                _filter = value;
                PerformFiltering();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
            }
        }

        public void PerformFiltering()
        {
            if (_filter == null)
            {
                _filter = "";
            }
            //If _filter has a value (ie. user entered something in Filter textbox)
            //Lower-case and trim string
            var lowerCaseFilter = Filter.ToLowerInvariant().Trim();

            //Use LINQ query to get all personmodel names that match filter text, as a list
            var result =
                _allPokemon.Where(d => d.Name.ToLowerInvariant()
                .Contains(lowerCaseFilter))
                .ToList();

            //Get list of values in current filtered list that we want to remove
            //(ie. don't meet new filter criteria)
            var toRemove = Pokemons.Except(result).ToList();

            //Loop to remove items that fail filter
            foreach (var x in toRemove)
            {
                Pokemons.Remove(x);
            }

            var resultCount = result.Count;
            // Add back in correct order.
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > Pokemons.Count || !Pokemons[i].Equals(resultItem))
                {
                    Pokemons.Insert(i, resultItem);
                }
            }
        }
    }
}
