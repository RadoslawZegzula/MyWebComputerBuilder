using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyOnlineShop.DataBaseAcces;
using MyOnlineShop.ProgramLogic;

using MyOnlineShop.Models;
using PagedList;
using PagedList.Mvc;

using static MyOnlineShop.ProgramLogic.SqlCreator;
using static MyOnlineShop.DataBaseAcces.UniversalDB;
using static MyOnlineShop.ProgramLogic.ComputerValidator;

namespace MyOnlineShop.Controllers
{
    public class ComputerController : Controller
    {

        public ActionResult Index(int? page, string computerPart = "Cpu")
        {
            var computer = new Computer
            {
                Id = 32131,
                IdClient = 32131,
                Comments = 32131,
                IdCpu = 32131,
                Likes = 32131
            };

            var pageNumber = (page ?? 1);

            var test = LoadData<PartsModel>(CreateSelect(computerPart));
            var customerMessage = "lolo";//ValidateComputer();
       

           var computerViewModel = new ComputerViewModel
           {
               ComputerM = computer, Parts=test.ToPagedList(pageNumber, 2),Token = computerPart, MessageToCustomer = customerMessage
           };

           return View(computerViewModel);          
        }


        public ActionResult Details(int id, string token)
        {

            object test;

            switch (token)
            {
                case "Cpu":
                    test = LoadData<Cpu>(CreateSelect(token, id))[0];
                    break;
                case "Computer":
                    test = LoadData<Cpu>(CreateSelect(token, id))[0];
                    break;
                default:
                    test = LoadData<Cpu>(CreateSelect(token, id))[0];
                    break;
            }

            return View(test);
        }

        public ActionResult Alter(int id, string partName)
        {
            string s = CreateUpdate(id, partName);
            int x=UpdateData(s);
            Console.WriteLine(s);
            return RedirectToAction("Index", "Computer");
        }
    }
}