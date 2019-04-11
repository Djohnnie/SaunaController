namespace SaunaController.Api.Services.Interfaces
{
    public interface ISaunaService
    {
        void TurnSaunaOn();

        void TurnSaunaOff();

        void TurnInfraredOn();

        void TurnInfraredOff();
    }
}