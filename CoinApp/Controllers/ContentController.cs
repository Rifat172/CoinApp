using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoinApp.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult CryptocurrencyQuotes()
        {
            return View();
        }
    }
}