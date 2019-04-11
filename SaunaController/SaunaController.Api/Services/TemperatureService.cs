using SaunaController.Api.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SaunaController.Api.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly String _sensorsSource = "/sys/bus/w1/devices/w1_bus_master1/w1_master_slaves";
        private readonly String _sensorSource = "/sys/bus/w1/devices/w1_bus_master1/{0}/w1_slave";

        public async Task<Int32> ReadTemperature()
        {
            Int32 temperature = 0;

            try
            {
                var sensors = await File.ReadAllLinesAsync(_sensorsSource);

                foreach (var sensor in sensors)
                {
                    var sensorSource = String.Format(_sensorSource, sensor);
                    if (File.Exists(sensorSource))
                    {
                        var sensorData = await File.ReadAllLinesAsync(sensorSource);
                        var temperatureData = sensorData[1].Substring(29, sensorData[1].Length - 29);
                        temperature = Convert.ToInt32(temperatureData);
                    }
                }
            }
            catch
            {
                // Nothing we can do...
            }

            return temperature;
        }
    }
}