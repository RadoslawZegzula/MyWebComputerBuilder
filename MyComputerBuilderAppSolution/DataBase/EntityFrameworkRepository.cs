using System;
using System.Collections.Generic;

namespace MyOnlineShop.DataBase 
{
    public class EntityFrameworkRepository : IRepository
    {
        public List<T> LoadParts<T>(string name)
        {
            throw new NotImplementedException();
        }

        public T LoadPart<T>(string tableName, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateComputerName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void InsertBlankComputer(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateComputer(int partId, int computerId, string partName, string userId)
        {
            throw new NotImplementedException();
        }

        public List<T> LoadComputersByUserId<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public List<T> LoadUserComputers<T>(string userId)
        {
            throw new NotImplementedException();
        }
    }
}