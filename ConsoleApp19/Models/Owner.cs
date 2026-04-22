namespace ConsoleApp19.Models
{
    public class Owner
    {
        public int OwnerID { get; }
        private string name;
        public string Name
        {
            get { return name; }

        }

        public Owner(string name, int id)
        {
            this.name = name;
            OwnerID = id;

        }

    }
}
