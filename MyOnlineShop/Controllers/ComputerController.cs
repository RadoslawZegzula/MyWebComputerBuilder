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
using Microsoft.AspNet.Identity;

using static MyOnlineShop.ProgramLogic.SqlCreator;
using static MyOnlineShop.DataBaseAcces.UniversalDB;
using static MyOnlineShop.ProgramLogic.ComputerValidator;

namespace MyOnlineShop.Controllers
{
    [Authorize]
    public class ComputerController : Controller
    {

        public ActionResult Index(int? page, int? computerId, string computerPart = "Cpu")
        {
            var userId = User.Identity.GetUserId();

            var computer = new Computer
            {
                Id = 32131,
                UserId = "32131",
                Comments = 32131,
                CpuId = 32131,
                Likes = 32131
            };

            var userComputers = LoadData<Computer>(SelectComputersByUserId(userId));
           

            if (userComputers.Count>0)
            {
                computer = computerId is null ? userComputers[0] : userComputers.Find(x => x.Id == computerId);
            }

            var cpu = computerId is null || computer.CpuId == 0 ? null : LoadData<PartsModel>(CreateSelect("Cpu", computer.CpuId))[0];
            var gpu = computerId is null || computer.GpuId == 0 ? null : LoadData<PartsModel>(CreateSelect("Gpu", computer.GpuId))[0];
            var motherboard = computerId is null || computer.MotherboardId == 0 ? null : LoadData<PartsModel>(CreateSelect("Motherboard", computer.MotherboardId))[0];
            var ram = computerId is null || computer.RamId == 0 ? null : LoadData<PartsModel>(CreateSelect("Ram", computer.RamId))[0];

            var myComputerParts = new Dictionary<string, PartsModel> {{"Cpu", cpu}, {"Gpu", gpu}, { "Motherboard", motherboard }, { "Ram", ram } };

            var pageNumber = (page ?? 1);

            var test = LoadData<PartsModel>(CreateSelect(computerPart));
            var messageToCustomer = ValidateComputer();
       

           var computerViewModel = new ComputerViewModel
           {
               ComputerM = computer,
               UserComputers = userComputers,
               MyComputerParts = myComputerParts,
               ShopParts = test.ToPagedList(pageNumber, 2),
               Token = computerPart,
               TextAndIconToCustomer = messageToCustomer,
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

        public ActionResult Alter(int partId, int computerId, string partName)
        {
            var userId = User.Identity.GetUserId();
            UpdateData(CreateUpdate(partId, computerId, partName, userId));

            return RedirectToAction("Index", "Computer",new{computerId});
        }

        public ActionResult AddComputer()
        {
            var userId = User.Identity.GetUserId();
            UpdateData(InsertComputerByUserId(userId));

            return RedirectToAction("Index", "Computer");
        }

        public ActionResult DeleteComputer(int deleteId)
        {
            var userId = User.Identity.GetUserId();
            UpdateData(DeleteComputerById(deleteId, userId));

            return RedirectToAction("Index", "Computer");
        }

        public ActionResult BuyPart(int partId)
        {
            var userId = User.Identity.GetUserId();
            return RedirectToAction("Index", "Computer");
        }
    }
}