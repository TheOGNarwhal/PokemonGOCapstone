using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class PokemonPO
    {
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public string Description { get; set; }
        public string FirstType { get; set; }
        public string SecondType { get; set; }
        public int PkFirstID { get; set; }
        public int PkSecondID { get; set; }
        public virtual bool EnableViewState { get; set; }
        public int SelectedID { get; set; }
    }
}