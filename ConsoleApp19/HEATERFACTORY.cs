using ConsoleApp19;



    public class HeaterFactory
    {
        public IHeaterStrategy CreateStrategy(int type)
        {
            return type switch
            {
                1 => new ElectricHeater(),
                2 => new GasHeater(),
                3 => new SolarStrategy(),
                _ => throw new Exception("Invalid type")
            };
        }
    }
