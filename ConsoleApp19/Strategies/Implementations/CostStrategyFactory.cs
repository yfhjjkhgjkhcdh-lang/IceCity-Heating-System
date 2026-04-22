public class CostStrategyFactory
{
    public ICostStrategy GetStrategy(CostType type)
    {
        return type switch
        {
            CostType.Standard => new StandardCostStrategy(),
            CostType.Eco => new EcoCostStrategy(),
            _ => throw new Exception("Invalid type")
        };
    }
}
public enum CostType
{
    Standard,
    Eco
}