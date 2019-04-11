using Microsoft.AspNetCore.Mvc;
using SaunaController.Api.Services.Interfaces;

namespace SaunaController.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaunaController : ControllerBase
    {
        private readonly ISaunaService _saunaService;

        public SaunaController(ISaunaService saunaService)
        {
            _saunaService = saunaService;
        }

        [HttpPut("on")]
        public IActionResult TurnOn()
        {
            _saunaService.TurnSaunaOn();
            return Ok();
        }

        [HttpPut("off")]
        public IActionResult TurnOff()
        {
            _saunaService.TurnSaunaOff();
            return Ok();
        }
    }
}