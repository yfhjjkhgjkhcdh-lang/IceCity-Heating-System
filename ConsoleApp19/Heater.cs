using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{

    public  class Heater

    {
        private readonly IHeaterStrategy _strategy;

        public Heater(IHeaterStrategy strategy)
        {
            _strategy = strategy;
        }

        public double CalcuateEffect(double value)
        {
            return _strategy.CalcuateEffect(value);
        }
        public string GetReportName()
        {
            return _strategy.GetName();
        }



        public int HeaterID { get; set; }
        public double power { get; set; }
        public object? HeaterId { get; internal set; }

        private DateTime? _lastopentime;
        public delegate void HeaterEventHandler(object sende);
        public delegate void HeaterDurationHandler(object sende, double hours);
        public event HeaterEventHandler? openHter;
        public event HeaterDurationHandler? closeHter;
        public void Open()
        {
            Random random = new Random();
            if (random.Next(0, 5) == 0)
            {
                throw new CHeaterFailedExceptioncs("HETAR FALIED");

            }
            _lastopentime = DateTime.UtcNow;
            openHter?.Invoke(this);
        }
        public void Close()
        {
            if (!_lastopentime.HasValue)
            {
                return;
            }
            double duration = (DateTime.UtcNow - _lastopentime.Value).TotalHours;

            closeHter?.Invoke(this, duration);
            _lastopentime = null;




        }
      





       




    }
}
