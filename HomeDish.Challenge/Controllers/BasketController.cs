using Microsoft.AspNetCore.Mvc;
using HomeDish.Challenge.Library.Class;
using HomeDish.Challenge.Library.Models;
using HomeDish.Challenge.Library.Interfaces;

namespace HomeDish.Challenge.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/basket")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class BasketController : ControllerBase
    {
        private readonly IService _basketService;
        public BasketController(IService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("total")]
        [MapToApiVersion("1.1")]
        public object SpecialTotal([FromBody] AggregateProduct basket)
        {
            if (basket.products != null)
            {
                return new Reply(new { total = _basketService.CalculateLowestTotal(basket) });
            }
            else
            {
                return new Reply(string.Empty, new Error("Request Payload Not Valid.", 1001));
            }
        }

        [HttpPost("total")]
        public object Total([FromBody] AggregateProduct basket)
        {
            if (basket.products != null)
            {
                return _basketService.CalculateLowestTotal(basket);
            }
            else
            {
                return BadRequest("Request Payload Not Valid.");
            }
        }
    }
}
