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
        public static string ValidateComputer()
        {

            var message = "ok";

            var cpu = LoadData<Cpu>(CreateSelect("Cpu",1))[0];
            //var gpu = LoadData<Gpu>(CreateSelect("Gpu", 1))[0];
            var motherboard = LoadData<MotherBoardModel>(CreateSelect("MotherBoard", 1))[0];

            if (cpu.Socket != motherboard.Socket)
            {
                message = "chujowy socket";
            }

            return message;
        }

    }
}