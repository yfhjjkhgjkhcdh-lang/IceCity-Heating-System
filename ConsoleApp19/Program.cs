using ConsoleApp19;
using System;
using System.Threading.Channels;
class Program
{
    static async Task Main(string[] args)
    {
        
        string ownerName;
        while (true)
        {
            Console.WriteLine("Enter owner name:");
            ownerName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(ownerName))
                break;

            Console.WriteLine("Invalid name, try again!");
        }
      


        int id;
        Console.WriteLine("Enter ownerID:");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID, enter number again:");
        }

        Owner owner = new Owner(ownerName, id);

       
        House houes = new House(owner);
        int choice = 0;
        bool isValid = false;

        while (!isValid)
        {
            Console.WriteLine("Choose Heater Type:");
            Console.WriteLine("1 - Electric");
            Console.WriteLine("2 - Gas");
            Console.WriteLine("3 - Solar");
            string input="";

            input = Console.ReadLine();

            if (input == "1")
            {
                choice = 1;
                isValid = true;
            }
            else if (input == "2")
            {
                choice = 2;
                isValid = true;
            }
            else if (input == "3")
            {
                choice = 3;
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again!");
            }
        }
        var factoryh=new HeaterFactory();
        var strategyh = factoryh.CreateStrategy(choice);
        var heater = new Heater(strategyh);



        houes.AddHeater(heater);
        houes.Subscribe(heater);

       

       
        HeatingService service = new HeatingService();
        var WeatherService= new WeatherService();
        var UsagePrinter = new UsagePrinter();
        await service.SafeOpenAsync(houes, 0);
        
        houes.Heaters[0]?.Close();

        var weatherData = await WeatherService.LoadLastMonthWeatherAsync();
        houes.DailyUses.AddRange(weatherData);


       
       
        DateTime now = DateTime.UtcNow.AddMonths(-1);
        int days = DateTime.DaysInMonth(now.Year, now.Month == 1 ? 12 : now.Month - 1);
        //Console.WriteLine();
       CostType type;

       

        while (true)
        {
            Console.WriteLine("Choose cost strategy:");
            Console.WriteLine("1 - Standard");
            Console.WriteLine("2 - Eco");

            string input = Console.ReadLine();

            if (input == "1")
            {
                type = CostType.Standard;
                break;
            }
            else if (input == "2")
            {
                type = CostType.Eco;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again!");
            }
        }



        UsagePrinter.PrintWithThreads(houes);
        await UsagePrinter.PrintWithTasks(houes);

          //Factory + Strategy
        var factory = new CostStrategyFactory();
        var strategy = factory.GetStrategy(type);

        
        var costService = new CostServicecs(strategy);

        
        report report = new report(costService);

        report.GenerateReport(houes, houes.Heaters, days);











        Console.ReadKey();
    }

  

    //enum HeaterType
    //{
    //    Electric=1,
    //    Gas=2,
        


    //};
   
}









