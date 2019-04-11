using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaunaController.Api.Services.Interfaces;

namespace SaunaController.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureService _temperatureService;

        public TemperatureController(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public async Task<IActionResult> TurnOn()
        {
            var temperature = await _temperatureService.ReadTemperature();
            return Ok(temperature);
        }
    }
}