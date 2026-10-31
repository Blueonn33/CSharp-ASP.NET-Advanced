namespace AutoMapperDemo.Models
{
    public class Vehicle
    {
        public Guid Id
        {
            get; set;
        }

        public string Make
        {
            get; set;
        }

        public string Model
        {
            get; set;
        }

        public int Year
        {
            get; set;
        }

        public int Mileage
        {
            get; set;
        }

        public int Seats
        {
            get; set;
        }

        public DateTime ProductionDate
        {
            get; set;
        }

        public string VIN
        {
            get; set;
        }

        public string[] FeaturesList
        {
            get; set;
        }
    }
}
