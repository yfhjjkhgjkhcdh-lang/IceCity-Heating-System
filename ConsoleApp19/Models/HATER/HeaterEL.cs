using ConsoleApp19.Strategies.Implementations;

internal class ElectricHeater : IHeaterStrategy

{


    public double CalcuateEffect(double VALUE)
    {
        return VALUE * 0.9;
    }
    public string GetName()
        => "Electric Heater";

}