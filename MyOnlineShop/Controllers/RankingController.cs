using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyOnlineShop.DataBaseAcces;
using PagedList.Mvc;
using PagedList;

namespace MyOnlineShop.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult Index(int? page)
        {
            var computerDb=new ComputerDb();
            var x = computerDb.SelectAllComputers();
            var pageNumber = (page ?? 1);

            return View(x.ToPagedList(pageNumber, 2));

        }
    }
}