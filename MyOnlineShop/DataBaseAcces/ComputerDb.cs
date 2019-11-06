using MyOnlineShop.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace MyOnlineShop.DataBaseAcces
{
    public class ComputerDb
    {

        private string TakeConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Azure"].ConnectionString;
        }

        public List<Computer> SelectAllComputers()
        {
            
            SqlConnection connection = new SqlConnection(TakeConnectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Computer ORDER BY Likes,Comments DESC", connection);
                List<Computer> computerList = new List<Computer>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var computer = new Computer
                    {
                        Id = reader.GetInt32(0),
                        IdClient = reader.GetInt32(1),
                        IdCpu = reader.GetInt32(2),
                        Comments = reader.GetInt32(3),
                        Likes = reader.GetInt32(4),
                    };

                    computerList.Add(computer);

                }
                return computerList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

    }
}