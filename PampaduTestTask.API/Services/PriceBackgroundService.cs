using PampaduTestTask.API.Contracts.Price;
using PampaduTestTask.DB.Entities;
using PampaduTestTask.DB.Repositories;
using System.Text.Json;

namespace PampaduTestTask.API.Services
{
    public class PriceBackgroundService : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PriceBackgroundService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PriceBackgroundService(HttpClient httpClient, ILogger<PriceBackgroundService> logger, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;

            _httpClient.BaseAddress = new Uri(configuration.GetSection("Api").GetValue<string>("PriceBaseAddressUri") ?? throw new InvalidOperationException("PriceBaseAddressUri is null"));
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var response = await _httpClient.GetFromJsonAsync<PriceResponse>("/v1/bpi/currentprice.json",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web),
                    cancellationToken: token);

                    if (response is not null)
                    {
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var _priceRepository = scope.ServiceProvider.GetRequiredService<IPriceRepository>();

                            await _priceRepository.CreatePrice(new Price
                            {
                                UsdRate = response?.Bpi?.Usd?.Rate ?? "Undefined",
                                GbpRate = response?.Bpi?.Gbp?.Rate ?? "Undefined",
                                EurRate = response?.Bpi?.Eur?.Rate ?? "Undefined",
                                UpdatedAt = response?.Time?.UpdatedISO ?? DateTime.MinValue,
                            });
                        }
                    }

                    await Task.Delay(30000, token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Price from Api");
            }
        }
    }
}