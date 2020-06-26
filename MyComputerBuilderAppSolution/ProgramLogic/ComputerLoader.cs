using System.Collections.Generic;
using MyOnlineShop.DataBase;
using MyOnlineShop.Models.Entities;
using PagedList;

namespace MyOnlineShop.ProgramLogic
{
    public class ComputerLoader
    {
        private readonly IRepository _dataBase;

        public ComputerEntity Computer;
        public CpuEntity Cpu;
        public GpuEntity Gpu;
        public MotherBoardEntity Motherboard;
        public RamEntity Ram;
        public PowerSupplyEntity PowerSupply;

        public ComputerLoader(string userId, int? computerId, IRepository db)
        {
            _dataBase = db;
            Computer = LoadComputer(userId, computerId);
            IsExist.CheckComputerAssign(Computer);
            LoadParts();
        }

        private ComputerEntity LoadComputer(string userId, int? computerId)
        {
            var userComputers = _dataBase.LoadComputersByUserId<ComputerEntity>(userId);

            if (computerId is null && userComputers.Count >= 1)
            {
                return userComputers[0];
            }

            return userComputers.Count == 1 ? userComputers[0] : userComputers.Find(x => x.Id == computerId);
        }

        public List<ComputerEntity> LoadUserComputers(string userId)
        {
            return _dataBase.LoadUserComputers<ComputerEntity>(userId);
        }

        public IPagedList<PartsBaseEntity> GetCatalogParts(int pageNumber, string searchedComputerPart)
        {
            return _dataBase.LoadParts<PartsBaseEntity>(searchedComputerPart).ToPagedList(pageNumber, 2);
        }

        private void LoadParts()
        {
            if (IsExist.Cpu)
            {
                LoadCpu();
            }

            if (IsExist.Gpu)
            {
                LoadGpu();
            }

            if (IsExist.Motherboard)
            {
                LoadMotherboard();
            }

            if (IsExist.Ram)
            {
                LoadRam();
            }

            if (IsExist.PowerSupply)
            {
                LoadPowerSupply();
            }
        }

        private void LoadCpu()
        {
            Cpu = _dataBase.LoadPart<CpuEntity>("Cpu", Computer.CpuId);
        }

        private void LoadGpu()
        {
            Gpu = _dataBase.LoadPart<GpuEntity>("Gpu", Computer.GpuId);
        }

        private void LoadMotherboard()
        {
            Motherboard = _dataBase.LoadPart<MotherBoardEntity>("Motherboard", Computer.MotherboardId);
        }

        private void LoadRam()
        {
            Ram = _dataBase.LoadPart<RamEntity>("Ram", Computer.RamId);
        }

        private void LoadPowerSupply()
        {
            PowerSupply = _dataBase.LoadPart<PowerSupplyEntity>("PowerSupply", Computer.PowerSupplyId);
        }
    }
}