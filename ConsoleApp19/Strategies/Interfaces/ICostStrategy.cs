using ConsoleApp19.Services;

public interface ICostStrategy
{
    double CalculateCost(double median, double totalHours, int days);
    double CalculateMedian(List<double> values);
    double CalculateTotalHours(List<DailyUse> dailyUses);
}