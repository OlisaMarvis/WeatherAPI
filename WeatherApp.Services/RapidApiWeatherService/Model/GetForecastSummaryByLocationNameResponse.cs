using Newtonsoft.Json;

namespace WeatherApp.Services.RapidApiWeatherService.Model
{
    public class GetForecastSummaryByLocationNameResponse
    {
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
        [JsonProperty(PropertyName = "forecast")]
        public Forecast Forecast { get; set; }
    }

    public class Astronomy
    {
        [JsonProperty(PropertyName = "dawn")]
        public DateTime Dawn { get; set; }
        [JsonProperty(PropertyName = "sunrise")]
        public DateTime Sunrise { get; set; }
        [JsonProperty(PropertyName = "suntransit")]
        public DateTime Suntransit { get; set; }
        [JsonProperty(PropertyName = "sunset")]
        public DateTime Sunset { get; set; }
        [JsonProperty(PropertyName = "dusk")]
        public DateTime Dusk { get; set; }
        [JsonProperty(PropertyName = "moonrise")]
        public DateTime Moonrise { get; set; }
        [JsonProperty(PropertyName = "moontransit")]
        public DateTime? Moontransit { get; set; }
        [JsonProperty(PropertyName = "moonset")]
        public DateTime? Moonset { get; set; }
        [JsonProperty(PropertyName = "moon_phase")]
        public int Moonphase { get; set; }
        [JsonProperty(PropertyName = "moon_illumination")]
        public int Moonzodiac { get; set; }
    }

    public class Coordinates
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
    }

    public class Forecast
    {
        [JsonProperty(PropertyName = "items")]
        public List<Item> Items { get; set; }
        [JsonProperty(PropertyName = "forecastDate")]
        public DateTime ForecastDate { get; set; }
        [JsonProperty(PropertyName = "nextUpdate")]
        public DateTime NextUpdate { get; set; }
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
        [JsonProperty(PropertyName = "point")]
        public string Point { get; set; }
        [JsonProperty(PropertyName = "fingerprint")]
        public string Fingerprint { get; set; }
    }

    public class Gusts
    {
        [JsonProperty(PropertyName = "value")]
        public int? Value { get; set; }
        [JsonProperty(PropertyName = "text")]
        public object Text { get; set; }
    }

    public class Item
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "dateWithTimezone")]
        public DateTime DateWithTimezone { get; set; }
        [JsonProperty(PropertyName = "freshSnow")]
        public double FreshSnow { get; set; }
        [JsonProperty(PropertyName = "snowHeight")]
        public object SnowHeight { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public Weather Weather { get; set; }
        [JsonProperty(PropertyName = "prec")]
        public Prec Prec { get; set; }
        [JsonProperty(PropertyName = "sunHours")]
        public int SunHours { get; set; }
        [JsonProperty(PropertyName = "rainHours")]
        public object RainHours { get; set; }
        [JsonProperty(PropertyName = "temperature")]
        public Temperature Temperature { get; set; }
        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }
        [JsonProperty(PropertyName = "windchill")]
        public Windchill Windchill { get; set; }
        [JsonProperty(PropertyName = "snowLine")]
        public SnowLine SnowLine { get; set; }
        [JsonProperty(PropertyName = "astronomy")]
        public Astronomy Astronomy { get; set; }
    }

    public class Location
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }
        [JsonProperty(PropertyName = "coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    public class Prec
    {
        [JsonProperty(PropertyName = "sum")]
        public double Sum { get; set; }
        [JsonProperty(PropertyName = "probability")]
        public int Probability { get; set; }
        [JsonProperty(PropertyName = "sumAsRain")]
        public object SumAsRain { get; set; }
    }

    
    public class SnowLine
    {
        [JsonProperty(PropertyName = "avg")]
        public object Avg { get; set; }
        [JsonProperty(PropertyName = "min")]
        public object Min { get; set; }
        [JsonProperty(PropertyName = "max")]
        public object Max { get; set; }
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }
    }

    public class Temperature
    {
        [JsonProperty(PropertyName = "min")]
        public int Min { get; set; }
        [JsonProperty(PropertyName = "max")]
        public int Max { get; set; }
        [JsonProperty(PropertyName = "avg")]
        public object Avg { get; set; }
    }

    public class Weather
    {
        [JsonProperty(PropertyName = "state")]
        public int State { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "avg")]
        public object Avg { get; set; }
        [JsonProperty(PropertyName = "min")]
        public int Min { get; set; }
        [JsonProperty(PropertyName = "max")]
        public int Max { get; set; }
        [JsonProperty(PropertyName = "gusts")]
        public Gusts Gusts { get; set; }
        [JsonProperty(PropertyName = "significationWind")]
        public bool SignificationWind { get; set; }
    }

    public class Windchill
    {
        [JsonProperty(PropertyName = "min")]
        public int Min { get; set; }
        [JsonProperty(PropertyName = "max")]
        public int Max { get; set; }
        [JsonProperty(PropertyName = "avg")]
        public object Avg { get; set; }
    }
}
