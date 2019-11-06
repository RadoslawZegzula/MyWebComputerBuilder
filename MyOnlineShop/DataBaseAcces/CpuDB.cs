using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOnlineShop.Models;


namespace MyOnlineShop.DataBaseAcces
{
    public class CpuDb
    {

        public string TakeConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Azure"].ConnectionString;
        }

        public List<Cpu> SelectAllCpu()
        {
            SqlConnection connection = new SqlConnection(TakeConnectionString());
           
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Cpu", connection);               
                List<Cpu> cpuArray = new List<Cpu>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var cpu = new Cpu
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        ImageUrl = reader.GetString(3)
                    };

                    cpuArray.Add(cpu);

                }
                return cpuArray;
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

        public Cpu SelectOneCpu(int id)
        {
            SqlConnection connection = new SqlConnection(TakeConnectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Cpu WHERE Id="+id, connection);
                Cpu cpu = new Cpu();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                     cpu = new Cpu
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        ImageUrl = reader.GetString(3)
                    };


                }
                return cpu;
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