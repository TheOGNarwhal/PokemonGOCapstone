using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DAL.DataAccessObjects;

namespace DAL
{
    public class GroupDataAccess
    {
        //Create a connection string to link to my pokemon data base and access the data
        static string connectionstring = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        //Create a method to view all groups
        public List<GroupDAO> GetAllGroups()
        {
            List<GroupDAO> grouplist = new List<GroupDAO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("sp_ViewGroups", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GroupDAO groupToList = new GroupDAO();
                                groupToList.GroupID = reader.GetInt32(0);
                                groupToList.GroupName = reader.GetString(1);
                                groupToList.GroupLeader = reader.GetString(2);
                                groupToList.GroupLeaderID = reader.GetInt32(3);
                                groupToList.Description = reader.GetString(4);
                                grouplist.Add(groupToList);
                            }
                        }
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
            return grouplist; 
        }
        //Create a new method to create a group
        public void CreateGroup(GroupDAO GroupToCreate)
        {
            try
            {
                //Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This creates a new database object
                    using (SqlCommand command = new SqlCommand("sp_CreateGroup", connection))
                    {
                        //This states what command type the object is
                        command.CommandType = CommandType.StoredProcedure;
                        //This adds the parameters nessicary for the stored procedure
                        command.Parameters.AddWithValue("@GroupName", GroupToCreate.GroupName);
                        command.Parameters.AddWithValue("@GroupLeader", GroupToCreate.GroupLeaderID);
                        command.Parameters.AddWithValue("@Description", GroupToCreate.Description);
                        //This opens a new connection to the database
                        connection.Open();
                        //This will excecute the above stored procedure
                        command.ExecuteNonQuery();
                        //This will close the database connection
                        connection.Close();
                        //This will dispose the database connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
        }
        //Create a new method to delete a group
        public void DeleteGroup(GroupDAO GroupToDelete)
        {
            try
            {
                //This creates a new connection to the Sql Database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This creates a new command object for the database
                    using (SqlCommand command = new SqlCommand("sp_DeleteGroup", connection))
                    {
                        //This specifies what type the command object is
                        command.CommandType = CommandType.StoredProcedure;
                        //This states the parameters for the stored procedure
                        command.Parameters.AddWithValue("@GroupID", GroupToDelete.GroupID);
                        //This opens the connection to the database
                        connection.Open();
                        //This executes the above stored procedure
                        command.ExecuteNonQuery();
                        //This closes the opened connection
                        connection.Close();
                        //This disposes the sql connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
        }
        //Create a new method to Update a group
        public void UpdateGroup(GroupDAO GroupToUpdate)
        {
            try
            {
                //This creates a new connection to the Sql database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This creates a new command object for the database
                    using (SqlCommand command = new SqlCommand("sp_UpdateGroup", connection))
                    {
                        //This specifies the command type the obbject is
                        command.CommandType = CommandType.StoredProcedure;
                        //This fills the value needed for the stored procedures
                        command.Parameters.AddWithValue("@GroupID", GroupToUpdate.GroupID);
                        command.Parameters.AddWithValue("@GroupName", GroupToUpdate.GroupName);
                        command.Parameters.AddWithValue("@GroupLeader", GroupToUpdate.GroupLeaderID);
                        command.Parameters.AddWithValue("@Description", GroupToUpdate.Description);
                        //This opens the connection to the database
                        connection.Open();
                        //This executes the stored procedure
                        command.ExecuteNonQuery();
                        //This closes the sql connection
                        connection.Close();
                        //This disposes the Sql Connection
                        connection.Dispose();
                    }
                }
            }
            catch (Exception errorCaught)
            {

            }
        }
    }
}
