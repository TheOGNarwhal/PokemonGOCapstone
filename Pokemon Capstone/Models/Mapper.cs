using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DataAccessObjects;

namespace Pokemon_Capstone.Models
{
    public class Mapper
    {
        public List<PokemonPO> PokemonMap(List<PokemonDAO> PokemonListToMap)
        {
            List<PokemonPO> PokemonListToReturn = new List<PokemonPO>();
            foreach (PokemonDAO PokemonToMap in PokemonListToMap)
            {
                PokemonPO PokemonToView = new PokemonPO();
                PokemonToView.PokemonID = PokemonToMap.PokemonID;
                PokemonToView.PokemonName = PokemonToMap.PokemonName;
                PokemonToView.Description = PokemonToMap.Description;
                PokemonToView.FirstType = PokemonToMap.FirstType;
                PokemonToView.PkFirstID = PokemonToMap.PkFirstID;
                PokemonToView.SecondType = PokemonToMap.SecondType;
                PokemonToView.PkSecondID = PokemonToMap.PkSecondID;
                PokemonListToReturn.Add(PokemonToView);
            }
            return PokemonListToReturn;
        }
        public List<UserPO> UserMap(List<UserDAO> UserListToMap)
        {
            List<UserPO> UserListToReturn = new List<UserPO>();
            foreach(UserDAO UserToMap in UserListToMap)
            {
                UserPO UserToView = new UserPO();
                UserToView.UserID = UserToMap.UserID;
                UserToView.Username = UserToMap.Username;
                UserToView.Password = UserToMap.Password;
                UserToView.FirstName = UserToMap.FirstName;
                UserToView.LastName = UserToMap.LastName;
                UserToView.Email = UserToMap.Email;
                UserToView.FavoritePokemon = UserToMap.FavoritePokemon;
                UserToView.FavoritePokemonID = UserToMap.FavoritePokemonID;
                UserToView.FavoriteType = UserToMap.FavoriteType;
                UserToView.FavoriteTypeID = UserToMap.FavoriteTypeID;
                UserToView.GroupOneName = UserToMap.GroupOneName;
                UserToView.GroupOneID = UserToMap.GroupOneID;
                UserToView.GroupTwoName = UserToMap.GroupTwoName;
                UserToView.GroupTwoID = UserToMap.GroupTwoID;
                UserToView.GroupThreeName = UserToMap.GroupThreeName;
                UserToView.GroupThreeID = UserToMap.GroupThreeID;
                UserToView.RoleName = UserToMap.RoleName;
                UserToView.RoleID = UserToMap.RoleID;
                UserListToReturn.Add(UserToView);
            }
            return UserListToReturn;
        }
        public PokemonDAO SinglePokemonMap(PokemonPO PokemonToMap)
        {
            PokemonDAO PokemonToReturn = new PokemonDAO();
            {
                PokemonDAO PokemonToView = new PokemonDAO();
                PokemonToView.PokemonID = PokemonToMap.PokemonID;
                PokemonToView.PokemonName = PokemonToMap.PokemonName;
                PokemonToView.Description = PokemonToMap.Description;
                PokemonToView.FirstType = PokemonToMap.FirstType;
                PokemonToView.PkFirstID = PokemonToMap.PkFirstID;
                PokemonToView.SecondType = PokemonToMap.SecondType;
                PokemonToView.PkSecondID = PokemonToMap.PkSecondID;
                PokemonToReturn = PokemonToView;
            }
            return PokemonToReturn;
        }
        public UserDAO SingleUserMap(UserPO UserToMap)
        {
            UserDAO UserToReturn = new UserDAO();
            {
                UserDAO UserToView = new UserDAO();
                UserToView.UserID = UserToMap.UserID;
                UserToView.Username = UserToMap.Username;
                UserToView.Password = UserToMap.Password;
                UserToView.FirstName = UserToMap.FirstName;
                UserToView.LastName = UserToMap.LastName;
                UserToView.Email = UserToMap.Email;
                UserToView.FavoritePokemon = UserToMap.FavoritePokemon;
                UserToView.FavoritePokemonID = UserToMap.FavoritePokemonID;
                UserToView.FavoriteType = UserToMap.FavoriteType;
                UserToView.FavoriteTypeID = UserToMap.FavoriteTypeID;
                UserToView.GroupOneName = UserToMap.GroupOneName;
                UserToView.GroupOneID = UserToMap.GroupOneID;
                UserToView.GroupTwoName = UserToMap.GroupTwoName;
                UserToView.GroupTwoID = UserToMap.GroupTwoID;
                UserToView.GroupThreeName = UserToMap.GroupThreeName;
                UserToView.GroupThreeID = UserToMap.GroupThreeID;
                UserToView.RoleName = UserToMap.RoleName;
                UserToView.RoleID = UserToMap.RoleID;
                UserToReturn = UserToView;
            }
            return UserToReturn;
        }
        public UserPO SelectUserMap(UserDAO UserToMap)
        {
            UserPO UserToReturn = new UserPO();
            {
                UserPO UserToView = new UserPO();
                UserToView.UserID = UserToMap.UserID;
                UserToView.Username = UserToMap.Username;
                UserToView.Password = UserToMap.Password;
                UserToView.FirstName = UserToMap.FirstName;
                UserToView.LastName = UserToMap.LastName;
                UserToView.Email = UserToMap.Email;
                UserToView.FavoritePokemon = UserToMap.FavoritePokemon;
                UserToView.FavoritePokemonID = UserToMap.FavoritePokemonID;
                UserToView.FavoriteType = UserToMap.FavoriteType;
                UserToView.FavoriteTypeID = UserToMap.FavoriteTypeID;
                UserToView.GroupOneName = UserToMap.GroupOneName;
                UserToView.GroupOneID = UserToMap.GroupOneID;
                UserToView.GroupTwoName = UserToMap.GroupTwoName;
                UserToView.GroupTwoID = UserToMap.GroupTwoID;
                UserToView.GroupThreeName = UserToMap.GroupThreeName;
                UserToView.GroupThreeID = UserToMap.GroupThreeID;
                UserToView.RoleName = UserToMap.RoleName;
                UserToView.RoleID = UserToMap.RoleID;
                UserToReturn = UserToView;
            }
            return UserToReturn;
        }
        public List<TypePO> TypeMap(List<TypeDAO> TypeListToMap)
        {
            List<TypePO> TypeListToReturn = new List<TypePO>();
            foreach (TypeDAO TypeToMap in TypeListToMap)
            {
                TypePO TypeToView = new TypePO();
                TypeToView.TypeID = TypeToMap.TypeID;
                TypeToView.TypeName = TypeToMap.TypeName;
                TypeToView.xNormal = TypeToMap.xNormal;
                TypeToView.xFire = TypeToMap.xFire;
                TypeToView.xWater = TypeToMap.xWater;
                TypeToView.xGrass = TypeToMap.xGrass;
                TypeToView.xElectric = TypeToMap.xElectric;
                TypeToView.xIce = TypeToMap.xIce;
                TypeToView.xFighting = TypeToMap.xFighting;
                TypeToView.xPoision = TypeToMap.xPoision;
                TypeToView.xGround = TypeToMap.xGround;
                TypeToView.xFlying = TypeToMap.xFlying;
                TypeToView.xPsychic = TypeToMap.xPsychic;
                TypeToView.xBug = TypeToMap.xBug;
                TypeToView.xRock = TypeToMap.xRock;
                TypeToView.xGhost = TypeToMap.xGhost;
                TypeToView.xDragon = TypeToMap.xDragon;
                TypeToView.xDark = TypeToMap.xDark;
                TypeToView.xSteel = TypeToMap.xSteel;
                TypeToView.xFairy = TypeToMap.xFairy;
                TypeListToReturn.Add(TypeToView);
            }
            return TypeListToReturn;
        }
        public List<GroupPO> GroupMap(List<GroupDAO> GroupListToMap)
        {
            List<GroupPO> GroupListToReturn = new List<GroupPO>();
            foreach (GroupDAO GroupToMap in GroupListToMap)
            {
                GroupPO GroupToView = new GroupPO();
                GroupToView.GroupID = GroupToMap.GroupID;
                GroupToView.GroupName = GroupToMap.GroupName;
                GroupToView.GroupLeader = GroupToMap.GroupLeader;
                GroupToView.GroupLeaderID = GroupToMap.GroupLeaderID;
                GroupToView.Description = GroupToMap.Description;
                GroupListToReturn.Add(GroupToView);
            }
            return GroupListToReturn;
        }
        public List<TeamPO> TeamsMap(List<TeamDAO> TeamListToMap)
        {
            List<TeamPO> TeamListToReturn = new List<TeamPO>();
            foreach (TeamDAO TeamToMap in TeamListToMap)
            {
                TeamPO TeamToList = new TeamPO();
                TeamToList.TeamID = TeamToMap.TeamID;
                TeamToList.TeamName = TeamToMap.TeamName;
                TeamToList.Creator = TeamToMap.Creator;
                TeamToList.CreatorID = TeamToMap.CreatorID;
                TeamToList.FirstPokemon = TeamToMap.FirstPokemon;
                TeamToList.FirstPkID = TeamToMap.FirstPkID;
                TeamToList.SecondPokemon = TeamToMap.SecondPokemon;
                TeamToList.SecondPkID = TeamToMap.SecondPkID;
                TeamToList.ThirdPokemon = TeamToMap.ThirdPokemon;
                TeamToList.ThirdPkID = TeamToMap.ThirdPkID;
                TeamToList.FourthPokemon = TeamToMap.FourthPokemon;
                TeamToList.FourthPkID = TeamToMap.FourthPkID;
                TeamToList.FifthPokemon = TeamToMap.FifthPokemon;
                TeamToList.FifthPkID = TeamToMap.FifthPkID;
                TeamToList.SixthPokemon = TeamToMap.SixthPokemon;
                TeamToList.SixthPkID = TeamToMap.SixthPkID;
                TeamListToReturn.Add(TeamToList);
            }
            return TeamListToReturn;
        }
        public TeamDAO SingleTeamMap(TeamPO TeamToCreate)
        {
                TeamDAO TeamToList = new TeamDAO();
                TeamToList.TeamID = TeamToCreate.TeamID;
                TeamToList.TeamName = TeamToCreate.TeamName;
                TeamToList.Creator = TeamToCreate.Creator;
                TeamToList.CreatorID = TeamToCreate.CreatorID;
                TeamToList.FirstPokemon = TeamToCreate.FirstPokemon;
                TeamToList.FirstPkID = TeamToCreate.FirstPkID;
                TeamToList.SecondPokemon = TeamToCreate.SecondPokemon;
                TeamToList.SecondPkID = TeamToCreate.SecondPkID;
                TeamToList.ThirdPokemon = TeamToCreate.ThirdPokemon;
                TeamToList.ThirdPkID = TeamToCreate.ThirdPkID;
                TeamToList.FourthPokemon = TeamToCreate.FourthPokemon;
                TeamToList.FourthPkID = TeamToCreate.FourthPkID;
                TeamToList.FifthPokemon = TeamToCreate.FifthPokemon;
                TeamToList.FifthPkID = TeamToCreate.FifthPkID;
                TeamToList.SixthPokemon = TeamToCreate.SixthPokemon;
                TeamToList.SixthPkID = TeamToCreate.SixthPkID;
            return TeamToList;
        }
        public TeamPO SelectTeamMap(TeamDAO TeamToCreate)
        {
            TeamPO TeamToList = new TeamPO();
            TeamToList.TeamID = TeamToCreate.TeamID;
            TeamToList.TeamName = TeamToCreate.TeamName;
            TeamToList.Creator = TeamToCreate.Creator;
            TeamToList.CreatorID = TeamToCreate.CreatorID;
            TeamToList.FirstPokemon = TeamToCreate.FirstPokemon;
            TeamToList.FirstPkID = TeamToCreate.FirstPkID;
            TeamToList.Pk1Type1 = TeamToCreate.Pk1Type1;
            TeamToList.Pk1Type1Name = TeamToCreate.Pk1Type1Name;
            TeamToList.Pk1Type2 = TeamToCreate.Pk1Type2;
            TeamToList.Pk1Type2Name = TeamToCreate.Pk1Type2Name;
            TeamToList.SecondPokemon = TeamToCreate.SecondPokemon;
            TeamToList.SecondPkID = TeamToCreate.SecondPkID;
            TeamToList.Pk2Type1 = TeamToCreate.Pk2Type1;
            TeamToList.Pk2Type1Name = TeamToCreate.Pk2Type1Name;
            TeamToList.Pk2Type2 = TeamToCreate.Pk2Type2;
            TeamToList.Pk2Type2Name = TeamToCreate.Pk2Type2Name;
            TeamToList.ThirdPokemon = TeamToCreate.ThirdPokemon;
            TeamToList.ThirdPkID = TeamToCreate.ThirdPkID;
            TeamToList.Pk3Type1 = TeamToCreate.Pk3Type1;
            TeamToList.Pk3Type1Name = TeamToCreate.Pk3Type1Name;
            TeamToList.Pk3Type2 = TeamToCreate.Pk3Type2;
            TeamToList.Pk3Type2Name = TeamToCreate.Pk3Type2Name;
            TeamToList.FourthPokemon = TeamToCreate.FourthPokemon;
            TeamToList.FourthPkID = TeamToCreate.FourthPkID;
            TeamToList.Pk4Type1 = TeamToCreate.Pk4Type1;
            TeamToList.Pk4Type1Name = TeamToCreate.Pk4Type1Name;
            TeamToList.Pk4Type2 = TeamToCreate.Pk4Type2;
            TeamToList.Pk4Type2Name = TeamToCreate.Pk4Type2Name;
            TeamToList.FifthPokemon = TeamToCreate.FifthPokemon;
            TeamToList.FifthPkID = TeamToCreate.FifthPkID;
            TeamToList.Pk5Type1 = TeamToCreate.Pk5Type1;
            TeamToList.Pk5Type1Name = TeamToCreate.Pk5Type1Name;
            TeamToList.Pk5Type2 = TeamToCreate.Pk5Type2;
            TeamToList.Pk5Type2Name = TeamToCreate.Pk5Type2Name;
            TeamToList.SixthPokemon = TeamToCreate.SixthPokemon;
            TeamToList.SixthPkID = TeamToCreate.SixthPkID;
            TeamToList.Pk6Type1 = TeamToCreate.Pk6Type1;
            TeamToList.Pk6Type1Name = TeamToCreate.Pk6Type1Name;
            TeamToList.Pk6Type2 = TeamToCreate.Pk6Type2;
            TeamToList.Pk6Type2Name = TeamToCreate.Pk6Type2Name;
            return TeamToList;
        }
    }
}