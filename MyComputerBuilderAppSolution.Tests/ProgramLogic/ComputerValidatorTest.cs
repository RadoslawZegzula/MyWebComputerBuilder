using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOnlineShop.DataBase;
using MyOnlineShop.Models;
using MyOnlineShop.Models.Entities;
using MyOnlineShop.ProgramLogic;

namespace MyOnlineShop.Tests.ProgramLogic
{
    [TestClass()]
    public class ComputerValidatorTest
    {
        private ComputerLoader _computerLoader;

        [TestInitialize]
        public void InitializeComputerValidatorTest(IRepository db)
        {       
            _computerLoader = new ComputerLoader("", null, db)
            {
                Cpu = new CpuEntity(),
                Gpu = new GpuEntity(),
                Motherboard = new MotherBoardEntity(),
                Ram = new RamEntity(),
                PowerSupply = new PowerSupplyEntity(),
            };
        }
        
        [TestMethod()]
        public void TheSameSocketTest()
        {
            _computerLoader.Cpu.Socket = "AM";
            _computerLoader.Motherboard.CpuSocket = "AM";

            var feedback = new ComputerValidator(_computerLoader).ValidateComputer();

            Assert.AreEqual("", feedback.Cpu.message);
            Assert.AreEqual("", feedback.Motherboard.message);
            Assert.AreEqual(Icon.ConfirmationIcon, feedback.Cpu.icon);
            Assert.AreEqual(Icon.ConfirmationIcon, feedback.Motherboard.icon);

        }

        [TestMethod()]
        public void OneSmallCaseSocketTest()
        {
            _computerLoader.Cpu.Socket = "am";
            _computerLoader.Motherboard.CpuSocket = "AM";

            var feedback = new ComputerValidator(_computerLoader).ValidateComputer();

            Assert.AreEqual(UnValidMessage.CpuSocket, feedback.Cpu.message);
            Assert.AreEqual(UnValidMessage.CpuSocket, feedback.Motherboard.message);
            Assert.AreEqual(Icon.ConfirmationIcon, feedback.Cpu.icon);
            Assert.AreEqual(Icon.ConfirmationIcon, feedback.Motherboard.icon);

        }

        [TestMethod()]
        public void DifferentSocketTest()
        {
            _computerLoader.Cpu.Socket = "Bad";
            _computerLoader.Motherboard.CpuSocket = "Good";

            var feedback = new ComputerValidator(_computerLoader).ValidateComputer();

            Assert.AreEqual(UnValidMessage.CpuSocket, feedback.Cpu.message);
            Assert.AreEqual(UnValidMessage.CpuSocket, feedback.Motherboard.message);
            Assert.AreEqual(Icon.WarningIcon, feedback.Cpu.icon);
            Assert.AreEqual(Icon.WarningIcon, feedback.Motherboard.icon);

        }


    }
}


