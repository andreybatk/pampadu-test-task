using System.Text.Json.Serialization;

namespace PampaduTestTask.API.Contracts.Price
{
    public class Currency
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
        [JsonPropertyName("rate")]
        public string? Rate { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("rate_float")]
        public float RateFloat { get; set; }
    }
}