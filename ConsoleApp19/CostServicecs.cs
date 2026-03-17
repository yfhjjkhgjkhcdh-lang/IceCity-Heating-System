using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class CostServicecs
    {
        private readonly ICostStrategy _strategy;
        public CostServicecs (ICostStrategy strategy)
        {
            _strategy = strategy;
        }
        public double CalculateMonthlyAverageCost(int day, Heater heater, House houes1)
        {
            List<double> heaterValues = new List<double>();
            foreach (var dailyUse in houes1.DailyUses)
            {
                if (dailyUse.workingHours > 0)
                {
                    heaterValues.Add(heater.CalcuateEffect(dailyUse.heaterValue));
                }
            }
            double median = _strategy.CalculateMedian(heaterValues);
            double totalHours = _strategy.CalculateTotalHours(houes1.DailyUses);

            return _strategy.CalculateCost(median, totalHours, day);
        }
    }


    
}
