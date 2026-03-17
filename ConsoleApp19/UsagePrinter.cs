using ConsoleApp19;

public class UsagePrinter
{
    public void PrintWithThreads(House house)
    {
        Thread t1 = new Thread(() => Print(house));
        Thread t2 = new Thread(() => Print(house));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }

    public async Task PrintWithTasks(House house)
    {
        var t1 = Task.Run(() => Print(house));
        var t2 = Task.Run(() => Print(house));

        await Task.WhenAll(t1, t2);
    }

    private void Print(House house)
    {
        foreach (var u in house.DailyUses)
        {
            Console.WriteLine(
                $"{u.Date:yyyy-MM-dd} | " +
                $"Hours={u.workingHours} | " +
                $"Value={u.heaterValue} | " +
                $"Thread={Thread.CurrentThread.ManagedThreadId}");
        }
    }
}