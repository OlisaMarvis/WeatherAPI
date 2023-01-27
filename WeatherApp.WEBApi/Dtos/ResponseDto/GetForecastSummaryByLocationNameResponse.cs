using Newtonsoft.Json;

namespace WeatherApp.WEBApi.Dtos.ResponseDto
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
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Lat { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public double Lon { get; set; }

        [JsonProperty(PropertyName = "tz_id")]
        public string TzId { get; set; }

        [JsonProperty(PropertyName = "localtime_epoch")]
        public int LocaltimeEpoch { get; set; }

        [JsonProperty(PropertyName = "localtime")]
        public string Localtime { get; set; }
    }

    public class GetForecast
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "date_epoch")]
        public int DateEpoch { get; set; }

        [JsonProperty(PropertyName = "day")]
        public GetForecastDay Day { get; set; }

        [JsonProperty(PropertyName = "astro")]
        public GetForecastAstro Astro { get; set; }

        [JsonProperty(PropertyName = "hour")]
        public List<GetForecastHour> Hour { get; set; }
    }
}
