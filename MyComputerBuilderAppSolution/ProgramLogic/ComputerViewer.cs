using System.Collections.Generic;
using MyOnlineShop.DataBase;
using MyOnlineShop.Models.Entities;
using MyOnlineShop.Models.ViewModels;
using PagedList;

namespace MyOnlineShop.ProgramLogic
{
    public class ComputerViewer
    {
        private readonly ComputerLoader _computerLoader;
        private readonly List<ComputerEntity> _userComputers;
        private IDictionary<string, PartsBaseEntity> _myComputerParts;
        private readonly IPagedList<PartsBaseEntity> _shopPartsPagedList;
        private readonly string _searchedComputerPart;
        private readonly Feedback _feedback;

        public ComputerViewer(string userId, int? page, int? computerId, IRepository db, string searchedComputerPart = "Cpu")
        {
            _computerLoader = new ComputerLoader(userId, computerId, db);
            _userComputers = _computerLoader.LoadUserComputers(userId);
            _searchedComputerPart = searchedComputerPart;
            _shopPartsPagedList = _computerLoader.GetCatalogParts(page ?? 1, searchedComputerPart);
            _feedback = new ComputerValidator(_computerLoader).ValidateComputer();

            PrepareParts();
        }

        public ComputerViewModel ReturnModel()
        {
            var computerViewModel = new ComputerViewModel
            {
                ComputerM = _computerLoader.Computer,
                UserComputers = _userComputers,
                MyComputerParts = _myComputerParts,
                ShopPartsPagedList = _shopPartsPagedList,
                ShopPartsFilteredByPartName = _searchedComputerPart,
                TextAndIconToCustomer = _feedback
            };

            return computerViewModel;
        }

        private void PrepareParts()
        {
            _myComputerParts = new Dictionary<string, PartsBaseEntity>
            {
                {"Cpu", _computerLoader.Cpu},
                {"Gpu", _computerLoader.Gpu},
                {"Motherboard", _computerLoader.Motherboard},
                {"Ram", _computerLoader.Ram},
                {"PowerSupply", _computerLoader.PowerSupply}
            };
        }
    }
}