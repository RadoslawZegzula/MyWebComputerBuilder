using System.Collections.Generic;

namespace MyOnlineShop.DataBase
{
    public interface IRepository
    {
        List<T> LoadParts<T>(string name);
        T LoadPart<T>(string tableName, int id);
        void UpdateComputerName(int id, string name);
        void Delete(int id, string userId);
        void InsertBlankComputer(string userId);
        void UpdateComputer(int partId, int computerId, string partName, string userId);
        List<T> LoadComputersByUserId<T>(string userId);
        List<T> LoadUserComputers<T>(string userId);
    }
}
