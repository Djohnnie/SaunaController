using Microsoft.AspNetCore.Mvc;
using SaunaController.Api.Services.Interfaces;

namespace SaunaController.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraredController : ControllerBase
    {
        private readonly ISaunaService _saunaService;

        public InfraredController(ISaunaService saunaService)
        {
            _saunaService = saunaService;
        }

        [HttpPut("on")]
        public IActionResult TurnOn()
        {
            _saunaService.TurnInfraredOn();
            return Ok();
        }

        [HttpPut("off")]
        public IActionResult TurnOff()
        {
            _saunaService.TurnInfraredOff();
            return Ok();
        }
    }
}