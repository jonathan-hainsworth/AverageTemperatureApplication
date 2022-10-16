namespace Models
{
    public class AverageTemperature
    {
        public double Temperature { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateOnly StartDay { get; set; }
        public DateOnly EndDay { get; set; }

        public bool isSuccessfull;
    }
}