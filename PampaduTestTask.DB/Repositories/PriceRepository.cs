using Dapper;
using PampaduTestTask.DB.Entities;
using System.Data;

namespace PampaduTestTask.DB.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly IDbConnection _context;

        public PriceRepository(IDbConnection context)
        {
            _context = context;
        }

        public async Task CreatePrice(Price price)
        {
            var query = @"insert into Prices
                (UsdRate, GbpRate, EurRate, UpdatedAt)
                values
                (@UsdRate, @GbpRate, @EurRate, @UpdatedAt)";

            await _context.ExecuteAsync(query, new { price.UsdRate, price.GbpRate, price.EurRate, price.UpdatedAt });
        }
        public async Task<List<Price>> GetPrices()
        {
            var query = $@"select * from Prices
                order by UpdatedAt";
            var prices = await _context.QueryAsync<Price>(query);
            return prices.ToList();
        }
        public async Task<Price?> GetById(int id)
        {
            var query = $@"select * from Prices
                where Id = @Id";
            var price = await _context.QueryFirstOrDefaultAsync<Price>(query, new { Id = id });
            return price;
        }
    }
}