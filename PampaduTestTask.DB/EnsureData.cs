using Dapper;
using System.Data;

namespace PampaduTestTask.DB
{
    public class EnsureData
    {
        private readonly IDbConnection _context;

        public EnsureData(IDbConnection context)
        {
            _context = context;
        }

        public void CreateTables()
        {
            var queryCreatePrices = @"
            CREATE TABLE IF NOT EXISTS Prices (
                Id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
                UsdRate TEXT NOT NULL,
                GbpRate TEXT NOT NULL,
                EurRate TEXT NOT NULL,
                UpdatedAt TIMESTAMP NOT NULL
            );";

            _context.Execute(queryCreatePrices);
        }
    }
}