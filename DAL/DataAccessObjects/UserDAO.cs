using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObjects
{
    public class UserDAO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
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
