using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Windows.Storage;
using FinalApp.Models;
using FinalApp.ViewModels;
using FinalApp;

namespace FinalApp.ViewModels
{
    public class PokemonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PokemonModel> Pokemons { get; set; }
        private List<PokemonModel> _allPokemon = new List<PokemonModel>();

        private string _filter;

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

        private void PerformFiltering()
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
