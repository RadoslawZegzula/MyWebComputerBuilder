﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOnlineShop.Models;
//using MyOnlineShop.DataBaseAcces;
using static MyOnlineShop.DataBaseAcces.UniversalDB;

namespace MyOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            //
            //return View();
            const string sql = "SELECT * FROM Cpu";

            return Content(""+LoadData<Cpu>(sql)[1].Name);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}