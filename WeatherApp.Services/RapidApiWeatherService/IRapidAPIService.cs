using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services.RapidApiWeatherService.Model;

namespace WeatherApp.Services.WeatherServices
{
    public interface IRapidAPIService
    {
        Task<GetForecastSummaryByLocationNameResponse> GetForecastSummaryByLocationName(string cityName);
    }
}
