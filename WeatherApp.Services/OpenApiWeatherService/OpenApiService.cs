using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services.OpenApiWeatherService.Model;
using WeatherApp.SharedKernel.HttpClientHelper;

namespace WeatherApp.Services.OpenApiWeatherService
{
    public class OpenApiService : IOpenApiService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public OpenApiService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }


        public async Task<CallCurrentWeatherResponse> GetWeatherAsync(string cityName)
        {
            var url = _configuration["OpenApi:GeoCodingUrl"];
            var APIkey = _configuration["OpenApi:AppId"];
            var requestUrl = $"{url}?q={cityName}&appid={APIkey}";
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", $"Bearer {_configuration["OpenApi:AppId"]}");

            var response = await _httpClientService.GetAsync<CallCurrentWeatherResponse>(requestUrl, headers);
            if (response.cod == 200)
            {
                var lon = String.Empty;
                var lat = String.Empty;
                var callCurrentWeatherRequest = new CallCurrentWeatherRequest
                {
                    lon = response.Coord.Lat,
                    lat = response.Coord.Lon
                };
                
                url = _configuration["OpenApi:BaseUrl"];
                APIkey = _configuration["OpenApi:AppId"];
                requestUrl = $"{url}?lat={callCurrentWeatherRequest.lat}&lon={callCurrentWeatherRequest.lon}&appid={APIkey}";

                response = await _httpClientService.GetAsync<CallCurrentWeatherResponse>(requestUrl, headers);
            }
            return response;

        }
    }
    
}
