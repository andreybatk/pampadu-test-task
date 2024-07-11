using Microsoft.AspNetCore.Mvc;
using PampaduTestTask.DB.Repositories;

namespace PampaduTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceRepository _priceRepository;

        public PricesController(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _priceRepository.GetById(id);

            if(data is null)
            {
                return BadRequest($"Price with id: {id} not found.");
            }

            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPrices()
        {
            var data = await _priceRepository.GetPrices();

            if (data is null)
            {
                return BadRequest($"Prices list empty.");
            }

            return Ok(data);
        }
    }
}