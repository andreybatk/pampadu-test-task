using System.Text.Json.Serialization;

namespace PampaduTestTask.API.Contracts.Price
{
    public class Time
    {
        [JsonPropertyName("updated")]
        public string? Updated { get; set; }
        [JsonPropertyName("updatedISO")]
        public DateTime UpdatedISO { get; set; }
        [JsonPropertyName("updateduk")]
        public string? UpdatedUK { get; set; }
    }
}