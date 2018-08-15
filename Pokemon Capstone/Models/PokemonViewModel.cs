using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class PokemonViewModel
    {
        public PokemonPO SinglePokemon { get; set; }
        public List<PokemonPO> PokemonList { get; set; }
        
        public PokemonViewModel()
        {
            SinglePokemon = new PokemonPO();
            PokemonList = new List<PokemonPO>();
        }
    }
}