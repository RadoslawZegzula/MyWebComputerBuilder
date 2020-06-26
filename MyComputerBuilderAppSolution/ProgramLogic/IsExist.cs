using MyOnlineShop.Models.Entities;

namespace MyOnlineShop.ProgramLogic
{
    public static class IsExist
    {
        public static bool Computer;
        public static bool Cpu;
        public static bool Gpu;
        public static bool Motherboard;
        public static bool Ram;
        public static bool PowerSupply;
        private static ComputerEntity _computer;

        public static void CheckComputerAssign(ComputerEntity computer)
        {
            _computer = computer;

            CheckComputerAssign();
            if (Computer)
            {
                CheckPartAssign();
            }
        }

        private static void CheckComputerAssign()
        {
            Computer = !(_computer is null);
        }

        public static void CheckPartAssign()
        {
            Cpu = _computer.CpuId != 0;
            Gpu = _computer.GpuId != 0;
            Motherboard = _computer.MotherboardId != 0;
            Ram = _computer.RamId != 0;
            PowerSupply = _computer.PowerSupplyId != 0;
        }

    }
}