using System.Web.Mvc;
using System.Web.Security;

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