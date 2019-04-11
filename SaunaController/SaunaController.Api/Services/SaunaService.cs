using SaunaController.Api.Services.Interfaces;
using System;
using System.Device.Gpio;

namespace SaunaController.Api.Services
{
    public class SaunaService : ISaunaService
    {
        private readonly GpioController _controller = new GpioController();
        private readonly Int32 _saunaPin = 17;
        private readonly Int32 _infraredPin = 27;

        public SaunaService()
        {
            _controller.OpenPin(_saunaPin, PinMode.Output);
            _controller.OpenPin(_infraredPin, PinMode.Output);
        }

        public void TurnSaunaOn()
        {
            SendSignal(_saunaPin, PinValue.High);
        }

        public void TurnSaunaOff()
        {
            SendSignal(_saunaPin, PinValue.Low);
        }

        public void TurnInfraredOn()
        {
            SendSignal(_infraredPin, PinValue.High);
        }

        public void TurnInfraredOff()
        {
            SendSignal(_infraredPin, PinValue.Low);
        }

        private void SendSignal(Int32 pinNumber, PinValue pinValue)
        {
            try
            {
                _controller.Write(pinNumber, pinValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}