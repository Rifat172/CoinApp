using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using CoinApp.Models;

namespace CustomRoleProviderApp.Controllers
{
    public class AccountController : Controller
    {
        UserContext db = new UserContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!HelperRegex.IsCorrectlyEmail(model.Email))
                {
                    ModelState.AddModelError("", "Некорретно введен Email");
                    return View(model);
                }
                User user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);


                if (user == null)
                {
                    db.Users.Add(new User { Email = model.Email, Password = model.Password, RoleId = 2 });
                    db.SaveChanges();
                    user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}