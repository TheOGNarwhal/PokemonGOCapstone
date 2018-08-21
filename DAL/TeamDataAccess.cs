using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BLL;
using DAL.DataAccessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TeamDataAccess
    {
        //Create a connection string to link to my pokemon data base and access the data
        static string connectionstring = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        //Create a new method to view all teams
        public List<TeamDAO> GetAllTeams()
        {
            //Create a new TeamDAO List named teamlist
            List<TeamDAO> teamlist = new List<TeamDAO>();
            try
            {
                //Create a new connection for the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a new command object for teh database
                    using (SqlCommand command = new SqlCommand("sp_ViewTeams", connection))
                    {
                        //Define what command to send to the database
                        command.CommandType = CommandType.StoredProcedure;
                        //Open the connection
                        connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Create a new teamDAO Variable to store values
                                TeamDAO TeamToList = new TeamDAO();
                                TeamToList.TeamID = reader.GetInt32(0);
                                TeamToList.TeamName = reader.GetString(1);
                                TeamToList.Creator = reader.GetString(2);
                                TeamToList.CreatorID = reader.GetInt32(3);
                                TeamToList.FirstPokemon = reader.GetString(4);
                                TeamToList.FirstPkID = reader.GetInt32(5);
                                TeamToList.SecondPokemon = reader.GetString(6);
                                TeamToList.SecondPkID = reader.GetInt32(7);
                                TeamToList.ThirdPokemon = reader.GetString(8);
                                TeamToList.ThirdPkID = reader.GetInt32(9);
                                TeamToList.FourthPokemon = reader.GetString(10);
                                TeamToList.FourthPkID = reader.GetInt32(11);
                                TeamToList.FifthPokemon = reader.GetString(12);
                                TeamToList.FifthPkID = reader.GetInt32(13);
                                TeamToList.SixthPokemon = reader.GetString(14);
                                TeamToList.SixthPkID = reader.GetInt32(15);
                                teamlist.Add(TeamToList);
                            }
                        }
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
            return teamlist;
        }
        //Create a new method to create a team
        public void CreateTeam(TeamDAO TeamToCreate)
        {
            try
            {
                //Create a new connection for the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a new command object for the database
                    using (SqlCommand command = new SqlCommand("sp_CreateTeam", connection))
                    {
                        //This specifies that its a stored procedure for the database 
                        command.CommandType = CommandType.StoredProcedure;
                        //This states the parameters for the stored procedure
                        command.Parameters.AddWithValue("@TeamName", TeamToCreate.TeamName);
                        command.Parameters.AddWithValue("@Creator", TeamToCreate.CreatorID);
                        command.Parameters.AddWithValue("@FirstPokemon", TeamToCreate.FirstPkID);
                        command.Parameters.AddWithValue("@SecondPokemon", TeamToCreate.SecondPkID);
                        command.Parameters.AddWithValue("@ThirdPokemon", TeamToCreate.ThirdPkID);
                        command.Parameters.AddWithValue("@FourthPokemon", TeamToCreate.FourthPkID);
                        command.Parameters.AddWithValue("@FifthPokemon", TeamToCreate.FifthPkID);
                        command.Parameters.AddWithValue("@SixthPokemon", TeamToCreate.SixthPkID);
                        //Open a new connection
                        connection.Open();
                        //Execute the sql command
                        command.ExecuteNonQuery();
                        //Close connection
                        connection.Close();
                        //Dispose Connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
        }
        //Create a new method to delete a team
        public void DeleteTeam(TeamDAO TeamToDelete)
        {
            try
            {
                //Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This states a command object for the database
                    using (SqlCommand command = new SqlCommand("sp_DeleteTeam", connection))
                    {
                        //This specifies that the object is going to execute a stored procedure for the dataase
                        command.CommandType = CommandType.StoredProcedure;
                        //This specifies the parameters for the stored procedure
                        command.Parameters.AddWithValue("@TeamID",TeamToDelete.TeamID);
                        //open the connection
                        connection.Open();
                        //Execute the command
                        command.ExecuteNonQuery();
                        //close the connection
                        connection.Close();
                        //Dispose the connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
        }
        //Create a new method to  update a team
        public void UpdateTeam(TeamDAO TeamToUpdate)
        {
            try
            {
                //Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This creates a new command object for the database
                    using (SqlCommand command = new SqlCommand("sp_UpdateTeam", connection))
                    {
                        //This states to the database that the command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        //This specifies the parameters for the database
                        command.Parameters.AddWithValue("@TeamID", TeamToUpdate.TeamID);
                        command.Parameters.AddWithValue("@TeamName", TeamToUpdate.TeamName);
                        command.Parameters.AddWithValue("@Creator", TeamToUpdate.CreatorID);
                        command.Parameters.AddWithValue("@FirstPokemon", TeamToUpdate.FirstPkID);
                        command.Parameters.AddWithValue("@SecondPokemon", TeamToUpdate.SecondPkID);
                        command.Parameters.AddWithValue("@ThirdPokemon", TeamToUpdate.ThirdPkID);
                        command.Parameters.AddWithValue("@FourthPokemon", TeamToUpdate.FourthPkID);
                        command.Parameters.AddWithValue("@FifthPokemon", TeamToUpdate.FifthPkID);
                        command.Parameters.AddWithValue("@SixthPokemon", TeamToUpdate.SixthPkID);
                        //Open the database connection
                        connection.Open();
                        //Execute the command above
                        command.ExecuteNonQuery();
                        //Close the connection
                        connection.Close();
                        //Dispose the connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
        }
        //Create a method to view a single users teams
        public List<TeamDAO> SelectUserTeams(TeamDAO TeamsToGet)
        {
            //Instantiate a new instance of the List<TeamDAO> object
            List<TeamDAO> teamlist = new List<TeamDAO>();
            //Create a new connection to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a new command for the database
                    using (SqlCommand command = new SqlCommand("sp_SelectUserTeams", connection))
                    {
                        //State that the command is a stored procedure for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //Add parameters for the storedprocedure
                        command.Parameters.AddWithValue("@UserID", TeamsToGet.CreatorID);
                        //Open the connection
                        connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Create a new teamDAO Variable to store values
                                TeamDAO TeamToList = new TeamDAO();
                                TeamToList.TeamID = reader.GetInt32(0);
                                TeamToList.TeamName = reader.GetString(1);
                                TeamToList.Creator = reader.GetString(2);
                                TeamToList.CreatorID = reader.GetInt32(3);
                                TeamToList.FirstPokemon = reader.GetString(4);
                                TeamToList.FirstPkID = reader.GetInt32(5);
                                TeamToList.SecondPokemon = reader.GetString(6);
                                TeamToList.SecondPkID = reader.GetInt32(7);
                                TeamToList.ThirdPokemon = reader.GetString(8);
                                TeamToList.ThirdPkID = reader.GetInt32(9);
                                TeamToList.FourthPokemon = reader.GetString(10);
                                TeamToList.FourthPkID = reader.GetInt32(11);
                                TeamToList.FifthPokemon = reader.GetString(12);
                                TeamToList.FifthPkID = reader.GetInt32(13);
                                TeamToList.SixthPokemon = reader.GetString(14);
                                TeamToList.SixthPkID = reader.GetInt32(15);
                                teamlist.Add(TeamToList);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return teamlist;
        }
        //Create a method to view a single team from the teams table
        public TeamDAO SelectTeam(TeamDAO TeamToGet)
        {
            TeamDAO TeamToReturn = new TeamDAO();  
            try
            {
                //Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a new command for the database
                    using (SqlCommand command = new SqlCommand("sp_SelectTeam", connection))
                    {
                        //State that the command is a stored procedure for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //Add parameters for the storedprocedure
                        command.Parameters.AddWithValue("@TeamID", TeamToGet.TeamID);
                        //Open the connection
                        connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Create a new teamDAO Variable to store values
                                TeamDAO TeamToList = new TeamDAO();
                                TeamToList.TeamID = reader.GetInt32(0);
                                TeamToList.TeamName = reader.GetString(1);
                                TeamToList.Creator = reader.GetString(2);
                                TeamToList.CreatorID = reader.GetInt32(3);
                                TeamToList.FirstPokemon = reader.GetString(4);
                                TeamToList.FirstPkID = reader.GetInt32(5);
                                TeamToList.Pk1Type1 = reader.GetInt32(6);
                                TeamToList.Pk1Type1Name = reader.GetString(7);
                                TeamToList.Pk1Type2 = reader.GetInt32(8);
                                TeamToList.Pk1Type2Name = reader.GetString(9);
                                TeamToList.SecondPokemon = reader.GetString(10);
                                TeamToList.SecondPkID = reader.GetInt32(11);
                                TeamToList.Pk2Type1 = reader.GetInt32(12);
                                TeamToList.Pk2Type1Name = reader.GetString(13);
                                TeamToList.Pk2Type2= reader.GetInt32(14);
                                TeamToList.Pk2Type2Name = reader.GetString(15);
                                TeamToList.ThirdPokemon = reader.GetString(16);
                                TeamToList.ThirdPkID = reader.GetInt32(17);
                                TeamToList.Pk3Type1 = reader.GetInt32(18);
                                TeamToList.Pk3Type1Name = reader.GetString(19);
                                TeamToList.Pk3Type2 = reader.GetInt32(20);
                                TeamToList.Pk3Type2Name = reader.GetString(21);
                                TeamToList.FourthPokemon = reader.GetString(22);
                                TeamToList.FourthPkID = reader.GetInt32(23);
                                TeamToList.Pk4Type1 = reader.GetInt32(24);
                                TeamToList.Pk4Type1Name = reader.GetString(25);
                                TeamToList.Pk4Type2 = reader.GetInt32(26);
                                TeamToList.Pk4Type2Name = reader.GetString(27);
                                TeamToList.FifthPokemon = reader.GetString(28);
                                TeamToList.FifthPkID = reader.GetInt32(29);
                                TeamToList.Pk5Type1 = reader.GetInt32(30);
                                TeamToList.Pk5Type1Name = reader.GetString(31);
                                TeamToList.Pk5Type2 = reader.GetInt32(32);
                                TeamToList.Pk5Type2Name = reader.GetString(33);
                                TeamToList.SixthPokemon = reader.GetString(34);
                                TeamToList.SixthPkID = reader.GetInt32(35);
                                TeamToList.Pk6Type1 = reader.GetInt32(36);
                                TeamToList.Pk6Type1Name = reader.GetString(37);
                                TeamToList.Pk6Type2 = reader.GetInt32(38);
                                TeamToList.Pk6Type2Name = reader.GetString(39);
                                TeamToReturn = TeamToList;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return TeamToReturn;
        }
        //Create a method to calculate the best and worst type for a team to face against
        static TypeDataAccess typeData = new TypeDataAccess();
        public TypeDAO CalculateTypes(List<int> TypesToCalculate)
        {
            TypeCalculator Calculator = new TypeCalculator();
            List<TypeDAO> AllDAOTypes = typeData.GetAllTypes();
            List<TypeBO> AllBOTypes = new List<TypeBO>();
            foreach (TypeDAO Types in AllDAOTypes)
            {
                TypeBO BOTypes = new TypeBO();
                BOTypes.TypeID = Types.TypeID;
                BOTypes.TypeName = Types.TypeName;
                BOTypes.xNormal = Types.xNormal;
                BOTypes.xFire = Types.xFire;
                BOTypes.xWater = Types.xWater;
                BOTypes.xGrass = Types.xGrass;
                BOTypes.xElectric = Types.xElectric;
                BOTypes.xIce = Types.xIce;
                BOTypes.xFighting = Types.xFighting;
                BOTypes.xPoision = Types.xPoision;
                BOTypes.xGround = Types.xGround;
                BOTypes.xFlying = Types.xFlying;
                BOTypes.xPsychic = Types.xPsychic;
                BOTypes.xBug = Types.xBug;
                BOTypes.xRock = Types.xRock;
                BOTypes.xGhost = Types.xGhost;
                BOTypes.xDragon = Types.xDragon;
                BOTypes.xDark = Types.xDark;
                BOTypes.xSteel = Types.xSteel;
                BOTypes.xFairy = Types.xFairy;
                AllBOTypes.Add(BOTypes);
            }
            List<TypeBO> TypesToEvaluate = new List<TypeBO>();
            foreach (int chosenType in TypesToCalculate)
            {
                if (chosenType != 19)
                {
                    foreach (TypeBO BOType in AllBOTypes)
                    {
                        if (chosenType == BOType.TypeID)
                        {
                            TypeBO Types = new TypeBO();
                            Types.TypeID = BOType.TypeID;
                            Types.TypeName = BOType.TypeName;
                            Types.xNormal = BOType.xNormal;
                            Types.xFire = BOType.xFire;
                            Types.xWater = BOType.xWater;
                            Types.xGrass = BOType.xGrass;
                            Types.xElectric = BOType.xElectric;
                            Types.xIce = BOType.xIce;
                            Types.xFighting = BOType.xFighting;
                            Types.xPoision = BOType.xPoision;
                            Types.xGround = BOType.xGround;
                            Types.xFlying = BOType.xFlying;
                            Types.xPsychic = BOType.xPsychic;
                            Types.xBug = BOType.xBug;
                            Types.xRock = BOType.xRock;
                            Types.xGhost = BOType.xGhost;
                            Types.xDragon = BOType.xDragon;
                            Types.xDark = BOType.xDark;
                            Types.xSteel = BOType.xSteel;
                            Types.xFairy = BOType.xFairy;
                            TypesToEvaluate.Add(Types);
                        }
                    }
                }
            }
            TypeBO FinalTypeValues = Calculator.Calculate(TypesToEvaluate);
            TypeDAO FinalValues = new TypeDAO();
            FinalValues.TypeID = FinalTypeValues.TypeID;
            FinalValues.TypeName = FinalTypeValues.TypeName;
            FinalValues.xNormal = FinalTypeValues.xNormal;
            FinalValues.xFire = FinalTypeValues.xFire;
            FinalValues.xWater = FinalTypeValues.xWater;
            FinalValues.xGrass = FinalTypeValues.xGrass;
            FinalValues.xElectric = FinalTypeValues.xElectric;
            FinalValues.xIce = FinalTypeValues.xIce;
            FinalValues.xFighting = FinalTypeValues.xFighting;
            FinalValues.xPoision = FinalTypeValues.xPoision;
            FinalValues.xGround = FinalTypeValues.xGround;
            FinalValues.xFlying = FinalTypeValues.xFlying;
            FinalValues.xPsychic = FinalTypeValues.xPsychic;
            FinalValues.xBug = FinalTypeValues.xBug;
            FinalValues.xRock = FinalTypeValues.xRock;
            FinalValues.xGhost = FinalTypeValues.xGhost;
            FinalValues.xDragon = FinalTypeValues.xDragon;
            FinalValues.xDark = FinalTypeValues.xDark;
            FinalValues.xSteel = FinalTypeValues.xSteel;
            FinalValues.xFairy = FinalTypeValues.xFairy;
            return FinalValues;
        }

    }
}

