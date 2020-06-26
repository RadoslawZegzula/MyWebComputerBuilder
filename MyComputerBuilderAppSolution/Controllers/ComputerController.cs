using System.Web.Mvc;
using MyOnlineShop.ProgramLogic;
using Microsoft.AspNet.Identity;
using MyOnlineShop.DataBase;
using MyOnlineShop.Models.Entities;

namespace MyOnlineShop.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IRepository _dataBase;

        public ComputerController(IRepository db)
        {
            _dataBase = db;
        }

        [HttpGet]
        public ActionResult Index(int? page, int? computerId, string computerPart = "Cpu")
        {
           var userId = User.Identity.GetUserId();
           var computerViewer = new ComputerViewer(userId, page, computerId, _dataBase, computerPart);

           return View(computerViewer.ReturnModel());          
        }

        [HttpGet]
        public ActionResult Details(int id, string token)
        {
            var model = _dataBase.LoadPart<PartsBaseEntity>(token, id);

            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Alter(int partId, int computerId, string partName)
        {
            var userId = User.Identity.GetUserId();
            _dataBase.UpdateComputer(partId, computerId, partName, userId);

            return RedirectToAction("Index", "Computer",new{computerId});
        }

        [HttpGet]
        public ActionResult AddComputer()
        {
            var userId = User.Identity.GetUserId();
            _dataBase.InsertBlankComputer(userId);

            return RedirectToAction("Index", "Computer");
        }

        [HttpGet]
        public ActionResult DeleteComputer(int deleteId)
        {
            var userId = User.Identity.GetUserId();
            _dataBase.Delete(deleteId, userId);

            return RedirectToAction("Index", "Computer");
        }

        [HttpGet]
        public ActionResult BuyPart(int partId)
        {
            return RedirectToAction("Index", "Computer");
        }

        [HttpGet]
        public ActionResult EditComputer(int id)
        {
            var model = _dataBase.LoadPart<ComputerEntity>("Computer", id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComputer(ComputerEntity computer)
        {
            _dataBase.UpdateComputerName(computer.Id, computer.Name);

            TempData["Message"] = "You have edited item";

            return RedirectToAction("Index");

        }

    }
}