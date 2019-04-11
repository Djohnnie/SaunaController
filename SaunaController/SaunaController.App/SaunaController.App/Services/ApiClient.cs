using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SaunaController.App.Services
{
    public class ApiClient
    {
        private readonly RestClient _client = new RestClient("http://192.168.10.124:8080/api");

        public Task TurnSaunaOn()
        {
            return SendAction("sauna/on");
        }

        public Task TurnSaunaOff()
        {
            return SendAction("sauna/off");
        }

        public Task TurnInfraredOn()
        {
            return SendAction("infrared/on");
        }

        public Task TurnInfraredOff()
        {
            return SendAction("infrared/off");
        }

        public async Task<Decimal> GetTemperature()
        {
            try
            {
                RestRequest request = new RestRequest("temperature", Method.GET);
                var result = await _client.ExecuteTaskAsync(request);
                return Convert.ToDecimal(result.Content) / 1000;
            }
            catch(Exception ex)
            {
                return 666;
            }
        }

        private async Task SendAction(String action)
        {
            try
            {
                RestRequest request = new RestRequest(action, Method.PUT);
                await _client.ExecuteTaskAsync(request);
            }
            catch
            {
                // Nothing we can do...
            }
        }
    }
}