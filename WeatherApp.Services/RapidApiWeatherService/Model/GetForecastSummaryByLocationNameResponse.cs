using Newtonsoft.Json;

namespace WeatherApp.Services.RapidApiWeatherService.Model
{
    public class GetForecastSummaryByLocationNameResponse
    {
        [JsonProperty(PropertyName = "location")]
        public List<GetForecastLocation> Location { get; set; }

        [JsonProperty(PropertyName = "forecast")]
        public List<GetForecast> Forecast { get; set; }
    }

    public class GetForecastLocation
    {
        [JsonProperty(PropertyName = "code")]
        public string code { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "coordinates")]
        public List<Coordinates> Coordinates { get; set; }
        
    }
    
    public class Coordinates
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longititude")]
        public double Longititude { get; set; }

    }

    public class GetForecast
    {
        [JsonProperty(PropertyName = "items")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "forecastDate")]
        public int forecastDate { get; set; }

        
    }
}
