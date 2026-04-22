using ConsoleApp19;
using ConsoleApp19.Strategies.Implementations;

public static class CityCenterService
{
    public static async Task<Heater> RequestReplacementAsync(Heater oldHeater)
    {
        await Task.Delay(1000);

        Console.WriteLine("Replacement requested.");


        return new Heater(GetSameStrategy(oldHeater));
    }

    private static IHeaterStrategy GetSameStrategy(Heater heater)
    {
        return heater.GetType() switch
        {
            _ => throw new Exception("Unknown type")
        };
    }
}