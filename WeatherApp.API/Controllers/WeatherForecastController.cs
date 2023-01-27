using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services.OpenApiWeatherService;
using WeatherApp.Services.WeatherServices;

namespace WeatherApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]{"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};
        private readonly IOpenApiService _openApiService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IOpenApiService openApiService, ILogger<WeatherForecastController> logger)
        {
            _openApiService = openApiService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Authorize]
        [Route("GetCurrentWeather")]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            var result = await _openApiService.GetWeatherAsync(city);
            return Ok(result);
        }
    }
}