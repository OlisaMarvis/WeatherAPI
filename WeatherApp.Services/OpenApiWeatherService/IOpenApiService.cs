using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services.OpenApiWeatherService.Model;

namespace WeatherApp.Services.OpenApiWeatherService
{
    public interface IOpenApiService
    {
        Task<CallCurrentWeatherResponse> GetWeatherAsync(string cityName);
    }
}
