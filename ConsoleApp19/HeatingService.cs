using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp19
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
                catch (CHeaterFailedExceptioncs)
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
