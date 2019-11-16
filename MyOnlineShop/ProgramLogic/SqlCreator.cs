using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOnlineShop.ProgramLogic
{
    public class SqlCreator
    {
        public static string CreateSelect(string partName)
        {
            var sqlString = $"SELECT * FROM {partName}";

            return sqlString;
        }

        public static string CreateSelect(string partName, int id)
        {
            var sqlString = $"SELECT * FROM {partName} WHERE Id = {id}";

            return sqlString;
        }

        public static string CreateSelect(string partName, string sortOrder)
        {
            var sqlString = $"SELECT * FROM {partName} ORDER BY {sortOrder}";

            return sqlString;
        }


        public static string SelectComputersByUserId(string userId)
        {
            var sqlString = $"SELECT * FROM computer WHERE UserId = '{userId}'";

            return sqlString;
        }

        public static string InsertComputerByUserId(string userId)
        {
            var sqlString = $"INSERT INTO computer (Name, UserId) VALUES('Computer Name', '{userId}')";

            return sqlString;
        }

        public static string DeleteComputerById(int deleteId, string userId)
        {
            var sqlString = $"DELETE FROM computer WHERE Id = {deleteId} AND UserId = '{userId}'";
            return sqlString;
        }

        public static string CreateUpdate(int partId, int computerId, string partName, string userId)
        {
            var tableNameOfPart = partName+"Id";
            var sqlString = $"UPDATE computer SET {tableNameOfPart} = {partId} WHERE Id = {computerId} AND UserId = '{userId}'";

            return sqlString;
        }



    }
}