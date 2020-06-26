using System.Web.Mvc;
using MyOnlineShop.DataBase;
using MyOnlineShop.Models.Entities;
using PagedList;

namespace MyOnlineShop.Controllers
{
    public class RankingController : Controller
    {
        private readonly IRepository _dataBase;

        public RankingController(IRepository db)
        {
            _dataBase = db;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var model = _dataBase.LoadParts<ComputerEntity>("Computer").ToPagedList(1, 50);
            return View(model);
        }
    }
}