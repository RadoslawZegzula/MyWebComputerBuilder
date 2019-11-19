using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyOnlineShop.Models;
using static MyOnlineShop.ProgramLogic.SqlCreator;
using static MyOnlineShop.DataBaseAcces.UniversalDB;

namespace MyOnlineShop.ProgramLogic
{
    public static class ComputerValidator
    {
        const string okeyIcon = "fas fa-check fa-border";
        const string warringIcon = "fas fa-exclamation-triangle fa-border";
        const string errorIcon = "fas fa-exclamation-circle fa - border";
    
        public static IDictionary<string, (string, string)> ValidateComputer()
        {

            IDictionary<string, (string,string)> dict = new Dictionary<string, (string,string)>();
            dict.Add("Cpu", ValidateCpu());
            dict.Add("Gpu", ValidateCpu());
            dict.Add("Motherboard", ValidateCpu());
            dict.Add("Ram", ValidateCpu());
     
            return dict;
        }

        public static (string, string) ValidateCpu()
        {

            var message="default message: ";
            string icon;
            
            var cpu = LoadData<Cpu>(CreateSelect("Cpu", 1))[0];
            var motherboard = LoadData<MotherBoardModel>(CreateSelect("MotherBoard", 1))[0];

            if (!string.Equals(cpu.Socket, motherboard.CpuSocket, StringComparison.CurrentCultureIgnoreCase))
            {
                message += $"socket is not valid, choose cpu with {cpu.Socket} socket or motherboard with {motherboard.CpuSocket} socket";
                icon = errorIcon;             
            }
            else
            {
                icon = okeyIcon;
            }

            return (message,icon);
        }
        public static string ValidateGpu()
        {
            return "l";
        }

    }
}