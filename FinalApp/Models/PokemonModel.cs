using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public PokemonModel(string name, string type, string category, string desc, string height, string weight)
        {
            this.Name = name;
            this.Type = type;
            this.Category = category;
            this.Description = desc;
            this.Height = height;
            this.Weight = weight;
        }
    }
}
