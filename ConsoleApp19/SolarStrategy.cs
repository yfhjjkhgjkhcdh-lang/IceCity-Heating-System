using ConsoleApp19;

public class SolarStrategy : IHeaterStrategy
{
    public double CalcuateEffect(double value)
    {
        return value * 0.7;
    }
    public string GetName()
      => "Solar Heater";

}