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
        public ActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {
            bool IsRegistred = false;
            using (UserContext db = new UserContext())
            {
                DbSet<User> users = db.Users;
                foreach(var u in users)
                {
                    IsRegistred = user.Equals(u);
                }
            }


            return RedirectToAction("CryptocurrencyQuotes", "Home", user);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult CryptocurrencyQuotes(User user)
        {
            return View();
        }
    }
}