using ConsoleApp19.Services;

namespace ConsoleApp19.Models
{
    public class House
    {
        public Owner Owner { get; }


        public List<Heater?> Heaters { get; }
        public List<DailyUse> DailyUses { get; }

        public House(Owner owner)
        {
            Owner = owner;
            Heaters = new List<Heater>();
            DailyUses = new List<DailyUse>();
        }

        public void AddHeater(Heater heater)
        {
            Heaters.Add(heater);
        }

        public void Subscribe(Heater heater)
        {
            heater.openHter += Heater_OpenHeater;
            heater.closeHter += OnHeaterClosed;
        }

        private void Heater_OpenHeater(object sender)
        {
            Console.WriteLine("Heater is open");
        }

        private void OnHeaterClosed(object sender, double hours)
        {
            Heater heater = (Heater)sender;

            var usage = new DailyUse(

                hours,
                heater.power, DateTime.UtcNow);

            DailyUses.Add(usage);

            Console.WriteLine(
                $"Heater {heater.HeaterId} closed. Hours: {hours:F4}");
        }
    }
}