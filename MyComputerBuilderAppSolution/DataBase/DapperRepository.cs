using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace MyOnlineShop.DataBase
{
    public class DapperRepository : IRepository
    {
        private static string TakeConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<T> LoadParts<T>(string tableName)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[selectAll]";
                var values = new {tableName};

                return cnn.Query<T>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public T LoadPart<T>(string tableName, int id)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[selectOneBy_tableName_id]";
                var values = new { tableName, id };

                return cnn.Query<T>(procedure, values, commandType: CommandType.StoredProcedure).First();
            }
        }

        public void UpdateComputerName(int id, string name)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[updateComputerNameBy_id_name]";
                var values = new { id, name };

                cnn.Execute(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id, string userId)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[deleteComputerBy_userId]";
                var values = new { userId };

                cnn.Execute(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertBlankComputer(string userId)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[insertBlankComputerBy_userId]";
                var values = new { userId };

                cnn.Execute(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateComputer(int partId,int computerId,string partName,string userId)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[updateComputerBy_partId_computerId_partName_userId]";
                var values = new { userId };

                cnn.Execute(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public List<T> LoadComputersByUserId<T>(string userId)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[selectComputersBy_userId]";
                var values = new {userId};

                return cnn.Query<T>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<T> LoadUserComputers<T>(string userId)
        {
            using (IDbConnection cnn = new SqlConnection(TakeConnectionString()))
            {
                const string procedure = "[selectUserComputersBy_userId]";
                var values = new { userId };

                return cnn.Query<T>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}