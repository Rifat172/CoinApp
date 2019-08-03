using CoinApp.Models.CoinData;
using System.Web.Mvc;
using System.Linq;
using System;

namespace CoinApp.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class ContentController : Controller
    {
        public ActionResult CryptocurrencyQuotes(string value)
        {
            var data = CallApi.GetObj(CallApi.MakeAPICall(50));
            ViewBag.Data = data;
            if (value != null)
            {
                int valueb = Convert.ToInt32(value);

                switch (valueb)
                {
                    case 0:
                        ViewBag.Data = data.OrderBy(o => o.Name);
                        return View();
                    case 1:
                        ViewBag.Data = data.OrderBy(o => o.Symbol);
                        return View();
                    case 2:
                        ViewBag.Data = data.OrderBy(o => o.Slug);
                        return View();
                    case 3:
                        ViewBag.Data = data.OrderBy(o => o.Quote.Usd.Price);
                        return View();
                    case 4:
                        ViewBag.Data = data.OrderBy(o => o.Quote.Usd.Percent_change_1h);
                        return View();
                    case 5:
                        ViewBag.Data = data.OrderBy(o => o.Quote.Usd.Percent_change_24h);
                        return View();
                    case 6:
                        ViewBag.Data = data.OrderBy(o => o.Quote.Usd.Market_cap);
                        return View();
                    case 7:
                        ViewBag.Data = data.OrderByDescending(o => o.Quote.Usd.Last_updated);
                        return View();
                    case 8:
                        ViewBag.Data = CallApi.GetObj(CallApi.MakeAPICall(50));
                        return View();
                    default:
                        return View();
                }//0-название, 1-символ, 2-логотип, 3-цена, 4-изменение1ч, 5-изменение24ч, 6-капита., 7-время.
            }
            return View();
        }
    }
}