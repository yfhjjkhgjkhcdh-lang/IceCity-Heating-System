using ConsoleApp19.Strategies.Implementations;

public class SolarStrategy : IHeaterStrategy
{
    public double CalcuateEffect(double value)
    {
        return value * 0.7;
    }
    public string GetName()
      => "Solar Heater";

}