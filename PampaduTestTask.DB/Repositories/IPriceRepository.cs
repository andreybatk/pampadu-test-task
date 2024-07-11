using PampaduTestTask.DB.Entities;

namespace PampaduTestTask.DB.Repositories
{
    public interface IPriceRepository
    {
        public Task CreatePrice(Price price);
        public Task<Price?> GetById(int id);
        public Task<List<Price>> GetPrices();
    }
}