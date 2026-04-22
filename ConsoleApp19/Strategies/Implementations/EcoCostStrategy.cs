using ConsoleApp19.Services;

public class EcoCostStrategy : ICostStrategy
{
    public double CalculateCost(double median, double totalHours, int days)
    {
        double cost = median * (totalHours / (24 * days));

        if (totalHours < 120)
            cost *= 0.9;

        return cost;
    }

    public double CalculateMedian(List<double> values)
    {
        values.Sort();
        int count = values.Count;

        if (count % 2 == 0)
            return (values[count / 2 - 1] + values[count / 2]) / 2;

        return values[count / 2];
    }

    public double CalculateTotalHours(List<DailyUse> dailyUses)
    {
        return dailyUses.Sum(d => d.workingHours);
    }
}