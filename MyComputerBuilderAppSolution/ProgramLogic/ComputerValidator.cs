using System;
using Microsoft.Ajax.Utilities;

namespace MyOnlineShop.ProgramLogic
{
    public class ComputerValidator
    {
        private readonly ComputerLoader _computerLoader;
        private readonly Feedback _feedback;

        public ComputerValidator(ComputerLoader computerLoader)
        {
            _computerLoader = computerLoader;
            _feedback = new Feedback();
        }

        public Feedback ValidateComputer()
        {
            PrepareComputerFeedback();

            return _feedback;
        }

        private void PrepareComputerFeedback()
        {
            if (IsExist.Cpu && IsExist.Motherboard)
            {
                ValidateCpuSocket();
            }

            if (IsExist.Ram && IsExist.Motherboard)
            {
                ValidateMotherboardSlots();
                ValidateRamConnectorType();
                ValidateRamMemoryType();
            }
        }

        private void ValidateCpuSocket()
        {
            if (IsNotEqualOrNull(_computerLoader.Cpu.Socket, _computerLoader.Motherboard.CpuSocket))
            {
                return;
            }

            _feedback.Cpu.message += UnValidMessage.CpuSocket;
            _feedback.Motherboard.message += UnValidMessage.CpuSocket;
            _feedback.Cpu.icon = Icon.ErrorIcon;
            _feedback.Motherboard.icon = Icon.ErrorIcon;
        }

        private void ValidateMotherboardSlots()
        {
            if ((_computerLoader.Motherboard.RamSlots >= _computerLoader.Ram.ModulesNumber))
            {
                return;
            }

            _feedback.Ram.message += UnValidMessage.MotherboardRamSlots;
            _feedback.Motherboard.message += UnValidMessage.MotherboardRamSlots;
            _feedback.Ram.icon = Icon.ErrorIcon;
            _feedback.Motherboard.icon = Icon.ErrorIcon;

        }

        private void ValidateRamConnectorType()
        {
            if (IsNotEqualOrNull(_computerLoader.Ram.ConnectorType,_computerLoader.Motherboard.ConnectorType))
            {
                return;
            }

            _feedback.Ram.message += UnValidMessage.RamMemoryType;
            _feedback.Motherboard.message += UnValidMessage.RamConnectorType;
            _feedback.Ram.icon = Icon.WarningIcon;
            _feedback.Motherboard.icon = Icon.WarningIcon;
        }

        private void ValidateRamMemoryType()
        {

            if (IsNotEqualOrNull(_computerLoader.Ram.MemoryType, _computerLoader.Motherboard.MemoryType))
            {
                return;
            }

            _feedback.Ram.message += UnValidMessage.RamMemoryType;
            _feedback.Motherboard.message += UnValidMessage.RamMemoryType;
            _feedback.Ram.icon = Icon.WarningIcon;
            _feedback.Motherboard.icon = Icon.WarningIcon;
        }

        private static bool IsNotEqualOrNull(string a, string b)
        {

            if (a.IsNullOrWhiteSpace() || b.IsNullOrWhiteSpace())
            {
                return true;
            }

            return !string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

    }
}