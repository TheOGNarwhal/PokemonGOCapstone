using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL;
using DAL.DataAccessObjects;
using System.Data.SqlClient;
using System.Data;
using Logger;
namespace DAL
{
    public class PokemonDataAccess
    {
        //Create a connection string to link to my pokemon data base and access the data
        static string connectionstring = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        //Create a method to view all pokemon in the pokemon table 
        public List<PokemonDAO> GetAllPokemon()
        {
            //Create a list variable called pokemonlist
            List<PokemonDAO> pokemonlist = new List<PokemonDAO>();
            try
            {
                //Establish the connection for the database 
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //establish the command to pass to the database and defining the comand
                    using (SqlCommand command = new SqlCommand("sp_ViewPokemon", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //Connecting to the database
                        connection.Open();
                        //Open the sql data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //Loop through the dataset and write each element into the PokemonToList
                            while (reader.Read())
                            {
                                PokemonDAO PokemonToList = new PokemonDAO();
                                PokemonToList.PokemonID = reader.GetInt32(0);
                                PokemonToList.PokemonName = reader.GetString(1);
                                PokemonToList.Description = reader.GetString(2);
                                PokemonToList.FirstType = reader.GetString(3);
                                PokemonToList.PkFirstID = reader.GetInt32(4);
                                PokemonToList.SecondType = reader.GetString(5);
                                PokemonToList.PkSecondID = reader.GetInt32(6);
                                pokemonlist.Add(PokemonToList);
                            }
                        }
                    }
                }
            }
            catch (Exception errorCaught )
            {
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
            //return the values recorded in the list
            return pokemonlist;
        }
        //Create a method to create a pokemon
        public void CreatePokemon(PokemonDAO PokemonToCreate)
        {
            try
            {
                //This is creating a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This specifies what kind of command object for the database
                    using (SqlCommand command = new SqlCommand("sp_CreatePokemon", connection))
                    {
                        //This specifies the command type is a stored procedure for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //These are the paramaters required for the stored procedure
                        command.Parameters.AddWithValue("@PokemonName", PokemonToCreate.PokemonName);
                        command.Parameters.AddWithValue("@Description", PokemonToCreate.Description);
                        command.Parameters.AddWithValue("@FirstType", PokemonToCreate.PkFirstID);
                        command.Parameters.AddWithValue("@SecondType", PokemonToCreate.PkSecondID);
                        //open the connection
                        connection.Open();
                        //This will execute the command
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
        }
        //Create a method to delete a pokemon
        public void DeletePokemon(PokemonDAO PokemonToDelete)
        {
            try
            {
                //This is creating a connection to  the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This specifies what kind of cammand object for the database
                    using (SqlCommand command = new SqlCommand("sp_DeletePokemon", connection))
                    {
                        //This specifies its a stored procedure to send to the database
                        command.CommandType = CommandType.StoredProcedure;
                        //This sends the parameters needed for the stored procedure 
                        command.Parameters.AddWithValue("@PokemonID", PokemonToDelete.PokemonID);
                        //This opens the sql connection
                        connection.Open();
                        //This will execute the command
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
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
        }
        //Create a method to update a pokemon
        public void UpdatePokemon(PokemonDAO PokemonToUdate)
        {
            try
            {
                //This is establishing connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This is to establish a command object for the database
                    using (SqlCommand command = new SqlCommand("sp_UpdatePokemon", connection))
                    {
                        //This establishes the command as a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        //These are the parameters for the Stored Procedures
                        command.Parameters.AddWithValue("@PokemonID",PokemonToUdate.PokemonID);
                        command.Parameters.AddWithValue("@PokemonName", PokemonToUdate.PokemonName);
                        command.Parameters.AddWithValue("@Description", PokemonToUdate.Description);
                        command.Parameters.AddWithValue("@FirstType", PokemonToUdate.PkFirstID);
                        command.Parameters.AddWithValue("@SecondType", PokemonToUdate.PkSecondID);
                        //Open the connection
                        connection.Open();
                        //This excecutes the stored procedure
                        command.ExecuteNonQuery();
                        //This closes the connection
                        connection.Close();
                        //This disposes the connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
        }
    }
}
