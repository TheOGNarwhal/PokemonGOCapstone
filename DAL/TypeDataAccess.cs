using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.DataAccessObjects;
using DAL;
using System.Data.SqlClient;
using Logger;

namespace DAL
{
    public class TypeDataAccess
    {
        //Create a connection string to link to my pokemon data base and access the data
        static string connectionstring = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        //Create a method to view all types
        public List<TypeDAO> GetAllTypes()
        {
            //Create a list variable for typelist
            List<TypeDAO> typelist = new List<TypeDAO>();
            try
            {
                //Establish the connection for the database
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    //This specifies the command object for the database
                    using (SqlCommand command = new SqlCommand("sp_ViewTypes", connection))
                    {
                        //this specifies that it is a stored procedure
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        //This opens the connection
                        connection.Open();
                        //open the sql data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //Loop through all the data in the set and write it to the typetolist list 
                            while (reader.Read())
                            {
                                TypeDAO typeToList = new TypeDAO();
                                typeToList.TypeID = reader.GetInt32(0);
                                typeToList.TypeName = reader.GetString(1);
                                typeToList.xNormal = reader.GetDecimal(2);
                                typeToList.xFire = reader.GetDecimal(3);
                                typeToList.xWater = reader.GetDecimal(4);
                                typeToList.xGrass = reader.GetDecimal(5);
                                typeToList.xElectric = reader.GetDecimal(6);
                                typeToList.xIce = reader.GetDecimal(7);
                                typeToList.xFighting = reader.GetDecimal(8);
                                typeToList.xPoision = reader.GetDecimal(9);
                                typeToList.xGround = reader.GetDecimal(10);
                                typeToList.xFlying = reader.GetDecimal(11);
                                typeToList.xPsychic = reader.GetDecimal(12);
                                typeToList.xBug = reader.GetDecimal(13);
                                typeToList.xRock = reader.GetDecimal(14);
                                typeToList.xGhost = reader.GetDecimal(15);
                                typeToList.xDragon = reader.GetDecimal(16);
                                typeToList.xDark = reader.GetDecimal(17);
                                typeToList.xSteel = reader.GetDecimal(18);
                                typeToList.xFairy = reader.GetDecimal(19);
                                typelist.Add(typeToList);
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
            return typelist;
        }
    }
}
