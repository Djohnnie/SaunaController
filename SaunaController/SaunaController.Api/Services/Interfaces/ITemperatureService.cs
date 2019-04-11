using System;
using System.Threading.Tasks;

namespace SaunaController.Api.Services.Interfaces
{
    public interface ITemperatureService
    {
        Task<Int32> ReadTemperature();
    }
}