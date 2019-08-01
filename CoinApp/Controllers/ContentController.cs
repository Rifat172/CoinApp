using CoinApp.Models.CoinData;
using System.Web.Mvc;

namespace CoinApp.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class ContentController : Controller
    {
        public ActionResult CryptocurrencyQuotes()
        {
            Cryptocurrency Cryptocurrencies = CallApi.GetObj();
            Data[] Data = Cryptocurrencies.Data;
            ViewBag.Data = Data;
            return View();
        }
    }
}