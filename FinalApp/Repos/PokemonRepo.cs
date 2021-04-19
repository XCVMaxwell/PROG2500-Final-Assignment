using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;

namespace FinalApp.Repos
{
    public class PokemonRepo
    {
        public static List<PokemonCard> GetAllPokemonCards()
        {
            // For some reason there are not async methods so I only get base set cards
            // else the program hangs for 3 minutes on launch getting all the cards
            // From what I can tell there are supposed to be async versions of all methods
            // but I can't use them https://github.com/PokemonTCG/pokemon-tcg-sdk-csharp
            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "set", "Base" }
            };

            return Card.Get<Pokemon>(query).Cards;
        }

        public static PokemonCard GetPokemonCard(string name, string set)
        {
            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "name", name },
                { "set", set }
            };

            return Card.Get<PokemonCard>(query);
        }
    }
}
