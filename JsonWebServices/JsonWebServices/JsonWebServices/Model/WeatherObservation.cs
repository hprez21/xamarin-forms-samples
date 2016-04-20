namespace JsonWebServices.Model
{

    public class WeatherResult
    {
        public Weatherobservation WeatherObservation { get; set; }
    }

    public class Weatherobservation
    {
        public int Elevation { get; set; }
        public float Lng { get; set; }
        public string Observation { get; set; }
        public string Icao { get; set; }
        public string Clouds { get; set; }
        public string DewPoint { get; set; }
        public string CloudsCode { get; set; }
        public string Datetime { get; set; }
        public string CountryCode { get; set; }
        public string Temperature { get; set; }
        public int Humidity { get; set; }
        public string StationName { get; set; }
        public string WeatherCondition { get; set; }
        public int WindDirection { get; set; }
        public int HectoPascAltimeter { get; set; }
        public string WindSpeed { get; set; }
        public float Lat { get; set; }
    }

}
