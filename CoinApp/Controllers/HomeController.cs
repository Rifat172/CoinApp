using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinApp.Models;
using System.Web.Mvc;
using System.Data.Entity;

namespace CoinApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}