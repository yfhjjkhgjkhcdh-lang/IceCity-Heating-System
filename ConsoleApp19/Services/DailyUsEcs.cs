namespace ConsoleApp19.Services
{
    public class DailyUse
    {
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {

                date = value;
            }
        }
        private double WorkingHours;
        public double workingHours
        {
            get { return WorkingHours; }
            set
            {


                WorkingHours = value;
            }
        }
        private double HeaterValue;
        public double heaterValue
        {
            get
            {
                return HeaterValue;
            }
            set
            {
                HeaterValue = value;

            }
        }
        public DailyUse(double workingHours, double heaterValue, DateTime date)
        {
            this.workingHours = workingHours;
            this.heaterValue = heaterValue;
            Date = date;
        }


    }
}
