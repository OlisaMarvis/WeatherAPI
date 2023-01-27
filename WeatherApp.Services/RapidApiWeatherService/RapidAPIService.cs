using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services.RapidApiWeatherService.Model;
using WeatherApp.SharedKernel.HttpClientHelper;

namespace WeatherApp.Services.WeatherServices
{
    public class RapidAPIService : IRapidAPIService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _httpClientService;

        public RapidAPIService(IConfiguration configuration, IHttpClientService httpClientService)
        {
            _configuration = configuration;
            _httpClientService = httpClientService;
        }
        
        public async Task<GetForecastSummaryByLocationNameResponse> GetForecastSummaryByLocationName(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }
            
            var url = _configuration["RapidApi:BaseUrl"];
            var headers = new Dictionary<string, string>();
            headers.Add("X-RapidAPI-Key", $"{_configuration["RapidApi:ApiKey"]}");
            headers.Add("X-RapidAPI-Host", $"{_configuration["RapidApi:Host"]}");
            var requestUrl = $"{url}{cityName}/summary/";

            var response = await _httpClientService.GetAsync<GetForecastSummaryByLocationNameResponse>(requestUrl, headers);
            return response;
        }
    }
}
