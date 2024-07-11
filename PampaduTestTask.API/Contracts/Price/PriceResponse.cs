using System.Text.Json.Serialization;

namespace PampaduTestTask.API.Contracts.Price
{
    public class PriceResponse
    {
        [JsonPropertyName("time")]
        public Time? Time { get; set; }
        [JsonPropertyName("disclaimer")]
        public string? Disclaimer { get; set; }
        [JsonPropertyName("chartName")]
        public string? ChartName { get; set; }
        [JsonPropertyName("bpi")]
        public Bpi? Bpi { get; set; }
    }
}