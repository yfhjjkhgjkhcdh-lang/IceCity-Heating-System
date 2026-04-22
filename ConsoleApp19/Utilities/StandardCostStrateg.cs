using ConsoleApp19.Services;
using ConsoleApp19.Utilities;

public class StandardCostStrategy : ICostStrategy
{
    public double CalculateCost(double median, double totalHours, int days)
    {
        return median * (totalHours / (24 * days));
    }

    public double CalculateMedian(List<double> values)
    {
        values.Sort();
        int count = values.Count;

        if (count.IsEven())
            return (values[count / 2 - 1] + values[count / 2]) / 2;

        return values[count / 2];
    }

    public double CalculateTotalHours(List<DailyUse> dailyUses)
    {
        return dailyUses.Sum(d => d.workingHours);
    }
}