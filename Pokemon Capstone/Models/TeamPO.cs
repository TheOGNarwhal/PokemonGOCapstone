using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class TeamPO
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public int CreatorID { get; set; }
        public string FirstPokemon { get; set; }
        public string SecondPokemon { get; set; }
        public string ThirdPokemon { get; set; }
        public string FourthPokemon { get; set; }
        public string FifthPokemon { get; set; }
        public string SixthPokemon { get; set; }
        public int FirstPkID { get; set; }
        public int SecondPkID { get; set; }
        public int ThirdPkID { get; set; }
        public int FourthPkID { get; set; }
        public int FifthPkID { get; set; }
        public int SixthPkID { get; set; }
        public int Pk1Type1 { get; set; }
        public int Pk1Type2 { get; set; }
        public int Pk2Type1 { get; set; }
        public int Pk2Type2 { get; set; }
        public int Pk3Type1 { get; set; }
        public int Pk3Type2 { get; set; }
        public int Pk4Type1 { get; set; }
        public int Pk4Type2 { get; set; }
        public int Pk5Type1 { get; set; }
        public int Pk5Type2 { get; set; }
        public int Pk6Type1 { get; set; }
        public int Pk6Type2 { get; set; }
        public string Pk1Type1Name { get; set; }
        public string Pk1Type2Name { get; set; }
        public string Pk2Type1Name { get; set; }
        public string Pk2Type2Name { get; set; }
        public string Pk3Type1Name { get; set; }
        public string Pk3Type2Name { get; set; }
        public string Pk4Type1Name { get; set; }
        public string Pk4Type2Name { get; set; }
        public string Pk5Type1Name { get; set; }
        public string Pk5Type2Name { get; set; }
        public string Pk6Type1Name { get; set; }
        public string Pk6Type2Name { get; set; }
        public int Max { get; set; }
        public string MaxName { get; set; }
        public int Max2 { get; set; }
        public string Max2Name { get; set; }
        public int Min { get; set; }
        public string MinName { get; set; }
        public int Min2 { get; set; }
        public string Min2Name { get; set; }
    }
}