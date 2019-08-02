using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Web;

namespace CoinApp.Models.CoinData
{
    public static class CallApi
    {
        public static List<Data> GetObj(string Json)
        {
            return JsonConvert.DeserializeObject<Cryptocurrency>(Json).Data;
        }
        public static string MakeAPICall(int limit)
        {
            string API_KEY = "b7e6263a-5a21-471c-abaa-f9b1da3262ab";
            UriBuilder URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = limit.ToString();
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            WebClient client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            string uri = URL.ToString();
            return client.DownloadString(uri);
        }
    }
}