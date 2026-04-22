using ConsoleApp19.Exceptions;
using ConsoleApp19.Models;
using ConsoleApp19.Exceptions;

namespace ConsoleApp19.Services
{
    internal class HeatingService
    {


        public async Task SafeOpenAsync(House house, int index)
        {
            var heater = house.Heaters[index];

            if (heater == null)
                return;

            try
            {
                heater.Open();
            }
            catch (CHeaterFailedExceptions)
            {
                Console.WriteLine("Heater failed!");

                var replacement =
                    await CityCenterService
                        .RequestReplacementAsync(heater);

                house.Heaters[index] = replacement;

                if (replacement != null)
                    house.Subscribe(replacement);
            }
        }














    }
}
