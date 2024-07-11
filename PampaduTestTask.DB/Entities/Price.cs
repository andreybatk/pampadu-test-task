namespace PampaduTestTask.DB.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public string UsdRate { get; set; } = string.Empty;
        public string GbpRate { get; set; } = string.Empty;
        public string EurRate { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}