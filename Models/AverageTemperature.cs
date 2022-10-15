namespace Models
{
    public class AverageTemperature
    {
        public double Temperature { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}