using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace MyOnlineShop.DataBaseAcces
{
    public class UniversalDB
    {
        public static string TakeConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Azure"].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }

        }
        public static int SaveData<T>(string sql,T data)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                return cnn.Execute(sql, data);
            }

        }

        public static int UpdateData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                return cnn.Execute(sql);
            }

        }
    }
}