using SaunaController.App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaunaController.App.ViewModels
{
    public class CommonViewModel : BaseViewModel
    {
        private readonly ApiClient _client = new ApiClient();

        private string _powerSaunaState = "power_off.png";
        private string _powerInfraredState = "power_off.png";
        private string _temperatureColor = "#EA5220";

        private string _temperature = "-";


        public ICommand PowerSaunaCommand { get; }
        public ICommand PowerInfraredCommand { get; }
        public ICommand SettingsCommand { get; }

        public string PowerSaunaState
        {
            get => _powerSaunaState;
            set
            {
                SetProperty(ref _powerSaunaState, value);
            }
        }

        public string PowerInfraredState
        {
            get => _powerInfraredState;
            set
            {
                SetProperty(ref _powerInfraredState, value);
            }
        }

        public string TemperatureColor
        {
            get => _temperatureColor;
            set
            {
                SetProperty(ref _temperatureColor, value);
            }
        }

        public string Temperature
        {
            get => _temperature;
            set
            {
                SetProperty(ref _temperature, value);
            }
        }

        public CommonViewModel()
        {
            PowerSaunaCommand = new Command(OnPowerSauna);
            PowerInfraredCommand = new Command(OnPowerInfrared);
            SettingsCommand = new Command(OnSettings);

            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(10000);
                    var temperature = await _client.GetTemperature();
                    Temperature = $"{temperature:F1}°C";
                }
            });
        }

        private void OnPowerSauna(object p)
        {
            if (PowerSaunaState == "power_off.png")
            {
                PowerSaunaState = "power_on.png";
                PowerInfraredState = "power_off.png";
                TemperatureColor = "#EA5220";
                _client.TurnInfraredOff();
                _client.TurnSaunaOn();
            }
            else
            {
                PowerSaunaState = "power_off.png";
                TemperatureColor = "#A8E820";
                TemperatureColor = "#2099E5";
                _client.TurnSaunaOff();
            }
        }

        private void OnPowerInfrared(object p)
        {
            if (PowerInfraredState == "power_off.png")
            {
                PowerInfraredState = "power_on.png";
                PowerSaunaState = "power_off.png";
                _client.TurnSaunaOff();
                _client.TurnInfraredOn();
            }
            else
            {
                PowerInfraredState = "power_off.png";
                _client.TurnInfraredOff();
            }
        }

        private void OnSettings(object p)
        {

        }
    }
}
