namespace AverageTemperatureApplication.Database
{
    public class CachedTemperatures
    {
        public int CachedTemperaturesId { get; set; }
        public double Temperature { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Day { get; set; }
    }
}
