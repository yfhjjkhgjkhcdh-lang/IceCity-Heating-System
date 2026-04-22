using ConsoleApp19.Services;
using System.Text.Json;

public class WeatherService
{
    public async Task<List<DailyUse>> LoadLastMonthWeatherAsync()
    {
        using var httpClient = new HttpClient();

        DateTime now = DateTime.UtcNow;
        DateTime start = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
        DateTime end = new DateTime(now.Year, now.Month, 1).AddDays(-1);

        string url =
            $"https://archive-api.open-meteo.com/v1/archive?" +
            $"latitude=31.0409&longitude=31.3785" +
            $"&start_date={start:yyyy-MM-dd}" +
            $"&end_date={end:yyyy-MM-dd}" +
            $"&daily=temperature_2m_max";

        var response = await httpClient.GetStringAsync(url);

        using var json = JsonDocument.Parse(response);

        var daily = json.RootElement.GetProperty("daily");

        var dates = daily.GetProperty("time").EnumerateArray();
        var temps = daily.GetProperty("temperature_2m_max").EnumerateArray();

        List<DailyUse> result = new();

        while (dates.MoveNext() && temps.MoveNext())
        {
            DateTime date = DateTime.Parse(dates.Current.GetString());
            double temp = temps.Current.GetDouble();

            double heaterValue = 500 + (25 - temp) * 10;

            result.Add(new DailyUse(5, heaterValue, date));
        }

        return result;
    }
}