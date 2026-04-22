using ConsoleApp19.Models;
using ConsoleApp19.Services;

namespace ConsoleApp19.Core
{
    internal class report
    {
        public CostServicecs CostServicecs { get; }
        public report(CostServicecs CostServicecs)
        {
            this.CostServicecs = CostServicecs;
        }
        public void GenerateReport(House houes1, List<Heater> heater, int day)
        {
            foreach (var item in heater)
            {
                double averageCost = CostServicecs.CalculateMonthlyAverageCost(day, item, houes1);
                if (heater.GetType() == typeof(ElectricHeater))
                {
                    Console.WriteLine("Electric Heater Report:");
                }
                else if (heater.GetType() == typeof(GasHeater))
                {
                    Console.WriteLine("Gas Heater Report:");
                }
                Console.WriteLine($"The average monthly cost of  heating is: {averageCost:C}");
            }
        }

    }
}
