namespace ShopTARge24.Models.OpenWeather
{
    public class OpenWeatherViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string Description { get; set; }
        public double WindSpeed { get; set; }
        public int Humidity { get; set; }
    }
}
