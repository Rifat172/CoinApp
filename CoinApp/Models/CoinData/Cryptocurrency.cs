using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoinApp.Models.CoinData
{
    public class Cryptocurrency
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
    public class Data
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("quote")]
        public Quote Quote { get; set; }
    }
    public class Quote
    {
        [JsonProperty("usd")]
        public USD Usd { get; set; }
    }
    public class USD
    {
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        [JsonProperty("percent_change_1h")]
        public decimal? Percent_change_1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public decimal? Percent_change_24h { get; set; }
        [JsonProperty("market_cap")]
        public double? Market_cap { get; set; }
        [JsonProperty("last_updated")]
        public string Last_updated { get; set; }
    }
}