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
            using (UserContext db = new UserContext())
            {
                DbSet<User> users = db.Users;
                foreach (User u in users)
                {
                    if (user.Equals(u))
                    {
                        user.Id = u.Id;
                        break;
                    }
                }
            }
            return RedirectToAction("CryptocurrencyQuotes", new { user.Id });
        }

        public ActionResult SignUp(string message)
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string Email, string Password, string Password1)
        {
            if (HelperRegex.IsCorrectlyEmail(Email))
            {
                if (Password == Password1)
                {
                    if (HelperRegex.IsCorrectlyPassword(Password))
                    {
                        using (UserContext db = new UserContext())
                        {
                            DbSet<User> users = db.Users;

                            foreach (var u in users)
                            {
                                if (Email == HelperRegex.RemoveSpace(u.Email))
                                    return RedirectToAction("SignUp", new { message = "Регистрация не прошла" });
                            }
                            db.Users.Add(new User { Email = Email, Password = Password });
                            db.SaveChanges();
                        }
                        return RedirectToAction("SignIn");
                    }
                }
            }
            return RedirectToAction("SignUp", new { message = "Регистрация не прошла" });
        }

        public ActionResult CryptocurrencyQuotes(int Id)
        {
            if (Id == 0)
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                return View();
            }
        }
    }
}