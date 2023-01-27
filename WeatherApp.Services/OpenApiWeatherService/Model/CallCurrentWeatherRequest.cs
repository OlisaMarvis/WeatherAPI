using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services.OpenApiWeatherService.Model
{
    public class CallCurrentWeatherRequest
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
}
