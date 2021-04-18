using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FinalApp.ViewModels;
using FinalApp.Models;

namespace FinalApp.Models
{
    public class PokemonModel
    {
        public string HP { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string[] Abilty { get; set; }
        public string[] Attack { get; set; }
        public string[] Weaknesses { get; set; }
        public string ImageURL { get; set; }

        public PokemonModel(string hp, string name, string type, string number, string[] abilty, string[] attack, string[] weaknesses, string imageURL)
        {
            this.HP = hp;
            this.Name = name;
            this.Type = type;
            this.Number = number;
            this.Abilty = abilty;
            this.Attack = attack;
            this.Weaknesses = weaknesses;
            this.ImageURL = imageURL;
        }
    }
}
