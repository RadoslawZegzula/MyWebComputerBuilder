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
            var sqlString = $"SELECT * FROM {partName} WHERE Id={id}";

            return sqlString;
        }

        public static string CreateSelect(string partName, string sortOrder)
        {
            var sqlString = $"SELECT * FROM {partName} ORDER BY {sortOrder}";

            return sqlString;
        }

        public static string CreateInsert(string partName, string sortOrder)
        {
            var sqlString = $"INSERT INTO {partName} (column1, column2, column3) VALUES(value1, value2, value3)";

            return sqlString;
        }

        public static string CreateUpdate(int id, string partName)
        {
            var sqlString = $"UPDATE Computer SET Comments=9999 WHERE Id=1";

            return sqlString;
        }



    }
}