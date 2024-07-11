using System.Text.Json.Serialization;

namespace PampaduTestTask.API.Contracts.Price
{
    public class Bpi
    {
        [JsonPropertyName("USD")]
        public Currency? Usd { get; set; }
        [JsonPropertyName("GBP")]
        public Currency? Gbp { get; set; }
        [JsonPropertyName("EUR")]
        public Currency? Eur { get; set; }
    }
}