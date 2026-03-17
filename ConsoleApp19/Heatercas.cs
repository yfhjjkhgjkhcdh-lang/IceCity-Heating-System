using ConsoleApp19;

internal class GasHeater : IHeaterStrategy

{
    public  double CalcuateEffect(double v)
    {
        
        return 0.8 * v;
    }
    public string GetName()
      => "Gas Heater";

}