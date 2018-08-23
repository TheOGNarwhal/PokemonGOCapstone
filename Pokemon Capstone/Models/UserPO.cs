using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pokemon_Capstone.Models
{
    public class UserPO
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "You Did Not Enter A Valid Username")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FavoritePokemon { get; set; }
        public int FavoritePokemonID { get; set; }
        public string FavoriteType { get; set; }
        public int FavoriteTypeID { get; set; }
        public string RoleName { get; set; }
        public int RoleID { get; set; }
        public int GroupOneID { get; set; }
        public string GroupOneName { get; set; }
        public int GroupTwoID { get; set; }
        public string GroupTwoName { get; set; }
        public int GroupThreeID { get; set; }
        public string GroupThreeName { get; set; }
    }
}