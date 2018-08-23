using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.DataAccessObjects;
using DAL;
using System.Data.SqlClient;
using System.Data;
using Logger;

namespace DAL
{
    public class UserDataAccess
    {
        //Create a connection string to link to my pokemon data base and access the data
        static string connectionstring = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        //Create a new method for viewing users
        public List<UserDAO> GetAllUsers()
        {
            //create a new instance of the UserDAO Variable
            List<UserDAO> userlist = new List<UserDAO>();
            try
            {
                //create a new connection to the sql database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //create a new command object for the sql database
                    using (SqlCommand command = new SqlCommand("sp_ViewUsers", connection))
                    {
                        //specify that the command is a stored procedure for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //Open a new connection to the database
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDAO UserToList = new UserDAO();
                                UserToList.UserID = reader.GetInt32(0);
                                UserToList.Username = reader.GetString(1);
                                UserToList.Password = reader.GetString(2);
                                UserToList.FirstName = reader.GetString(3);
                                UserToList.LastName = reader.GetString(4);
                                UserToList.Email = reader.GetString(5);
                                UserToList.FavoritePokemon = reader.GetString(6);
                                UserToList.FavoritePokemonID = reader.GetInt32(7);
                                UserToList.FavoriteType = reader.GetString(8);
                                UserToList.FavoriteTypeID = reader.GetInt32(9);
                                UserToList.GroupOneName = reader.GetString(10);
                                UserToList.GroupOneID = reader.GetInt32(11);
                                UserToList.GroupTwoName = reader.GetString(12);
                                UserToList.GroupTwoID = reader.GetInt32(13);
                                UserToList.GroupThreeName = reader.GetString(14);
                                UserToList.GroupThreeID = reader.GetInt32(15); 
                                UserToList.RoleName = reader.GetString(16);
                                UserToList.RoleID = reader.GetInt32(17);
                                userlist.Add(UserToList);
                            }
                        }
                    }
                }
            }
            catch (Exception errorCaught)
            {
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
            return userlist;
        }
        //Create a new method for creating a User
        public void CreateUser(UserDAO UserToCreate)
        {
            try
            {
                //Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a Command object for the database
                    using (SqlCommand command = new SqlCommand("sp_CreateUser", connection))
                    {
                        //Tell the database the object is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        //These are the parameters needed for the stored procedure
                        command.Parameters.AddWithValue("@UserName", UserToCreate.Username);
                        command.Parameters.AddWithValue("@Password", UserToCreate.Password);
                        command.Parameters.AddWithValue("@FirstName", UserToCreate.FirstName);
                        command.Parameters.AddWithValue("@LastName", UserToCreate.LastName);
                        command.Parameters.AddWithValue("@Email", UserToCreate.Email);
                        //This opens the connetion
                        connection.Open();
                        //This excecutes the command
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
        //Create a new method for deleting a user
        public void DeleteUser(UserDAO UserToDelete)
        {
            try
            {
                //Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a new database object ccommand
                    using (SqlCommand command = new SqlCommand("sp_DeleteUser", connection))
                    {
                        //Tell the database the object is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        //These are the parameters for the stored procedure
                        command.Parameters.AddWithValue("@UserID", UserToDelete.UserID);
                        //open up the sql connection
                        connection.Open();
                        //Execute the above command
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
        //Create a method for updating users
        public void UpdateUser(UserDAO UserToUpdate)
        {
            try
            {
                //Create the connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a comand object for the database
                    using (SqlCommand command = new SqlCommand("sp_UpdateUser", connection))
                    {
                        //State the command type for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //State the parameters for the stored procedure
                        command.Parameters.AddWithValue("@UserID", UserToUpdate.UserID);
                        command.Parameters.AddWithValue("@UserName", UserToUpdate.Username);
                        command.Parameters.AddWithValue("@Password", UserToUpdate.Password);
                        command.Parameters.AddWithValue("@FirstName", UserToUpdate.FirstName);
                        command.Parameters.AddWithValue("@LastName", UserToUpdate.LastName);
                        command.Parameters.AddWithValue("@Email", UserToUpdate.Email);
                        command.Parameters.AddWithValue("@FavoritePokemon", UserToUpdate.FavoritePokemonID);
                        command.Parameters.AddWithValue("@FavoriteType", UserToUpdate.FavoriteTypeID);
                        command.Parameters.AddWithValue("@FirstGroup", UserToUpdate.GroupOneID);
                        command.Parameters.AddWithValue("@SecondGroup", UserToUpdate.GroupTwoID);
                        command.Parameters.AddWithValue("@ThirdGroup", UserToUpdate.GroupThreeID);
                        command.Parameters.AddWithValue("@RoleID", UserToUpdate.RoleID);
                        //Open the connection to the database
                        connection.Open();
                        //Execute the above command
                        command.ExecuteNonQuery();
                        //Close the connection to the database
                        connection.Close();
                        //Dispose the connection to the database
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
        //Create a method for logging in
        public UserDAO UserLogin(UserDAO UserToLogin)
        {
            UserDAO loggeduser = new UserDAO();
            try
            {
                //create a new connection to the sql database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //create a new command object for the sql database
                    using (SqlCommand command = new SqlCommand("sp_UserLogin", connection))
                    {
                        //specify that the command is a stored procedure for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //Send the value of the parameters to the database
                        command.Parameters.AddWithValue("@Username", UserToLogin.Username);
                        command.Parameters.AddWithValue("@Password", UserToLogin.Password);
                        //Open a new connection to the database
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDAO UserToList = new UserDAO();
                                UserToList.UserID = reader.GetInt32(0);
                                UserToList.Username = reader.GetString(1);
                                UserToList.Password = reader.GetString(2);
                                UserToList.FirstName = reader.GetString(3);
                                UserToList.LastName = reader.GetString(4);
                                UserToList.Email = reader.GetString(5);
                                UserToList.FavoritePokemon = reader.GetString(6);
                                UserToList.FavoritePokemonID = reader.GetInt32(7);
                                UserToList.FavoriteType = reader.GetString(8);
                                UserToList.FavoriteTypeID = reader.GetInt32(9);
                                UserToList.GroupOneName = reader.GetString(10);
                                UserToList.GroupOneID = reader.GetInt32(11);
                                UserToList.GroupTwoName = reader.GetString(12);
                                UserToList.GroupTwoID = reader.GetInt32(13);
                                UserToList.GroupThreeName = reader.GetString(14);
                                UserToList.GroupThreeID = reader.GetInt32(15);
                                UserToList.RoleName = reader.GetString(16);
                                UserToList.RoleID = reader.GetInt32(17);
                                loggeduser = UserToList;
                            }
                        }
                    }
                }
            }
            catch (Exception errorCaught)
            {
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
            return loggeduser;
        }
        //Create a method for selecting a single user
        public UserDAO SelectUser(UserDAO UserToLogin)
        {
            UserDAO userProfile = new UserDAO();
            try
            {
                //create a new connection to the sql database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //create a new command object for the sql database
                    using (SqlCommand command = new SqlCommand("sp_SelectUser", connection))
                    {
                        //specify that the command is a stored procedure for the database
                        command.CommandType = CommandType.StoredProcedure;
                        //Send the value of the parameters to the database
                        command.Parameters.AddWithValue("@UserID", UserToLogin.UserID);
                        //Open a new connection to the database
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDAO UserToList = new UserDAO();
                                UserToList.UserID = reader.GetInt32(0);
                                UserToList.Username = reader.GetString(1);
                                UserToList.Password = reader.GetString(2);
                                UserToList.FirstName = reader.GetString(3);
                                UserToList.LastName = reader.GetString(4);
                                UserToList.Email = reader.GetString(5);
                                UserToList.FavoritePokemon = reader.GetString(6);
                                UserToList.FavoritePokemonID = reader.GetInt32(7);
                                UserToList.FavoriteType = reader.GetString(8);
                                UserToList.FavoriteTypeID = reader.GetInt32(9);
                                UserToList.GroupOneName = reader.GetString(10);
                                UserToList.GroupOneID = reader.GetInt32(11);
                                UserToList.GroupTwoName = reader.GetString(12);
                                UserToList.GroupTwoID = reader.GetInt32(13);
                                UserToList.GroupThreeName = reader.GetString(14);
                                UserToList.GroupThreeID = reader.GetInt32(15);
                                UserToList.RoleName = reader.GetString(16);
                                UserToList.RoleID = reader.GetInt32(17);
                                userProfile = UserToList;
                            }
                        }
                    }
                }
            }
            catch (Exception errorCaught)
            {
                ErrorLogger errorToLog = new ErrorLogger();
                errorToLog.errorlogger(errorCaught);
            }
            return userProfile;
        }
        //Create a method to reset a password
        public void ResetPassword(UserDAO UserToReset)
        {
            try
            {
                //Create a new sql connection
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //Create a new Sql command obhject
                    using (SqlCommand command = new SqlCommand("sp_ResetPassword", connection))
                    {
                        //This states the command type for the object
                        command.CommandType = CommandType.StoredProcedure;
                        //This specifies the parameters for the command
                        command.Parameters.AddWithValue("@UserID", UserToReset.UserID);
                        //Open the Sql Connection
                        connection.Open();
                        //Excecute the command
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
    }
}
