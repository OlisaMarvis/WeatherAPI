using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherApp.WEBApi.Models;

namespace WeatherApp.WEBApi.Data
{
    public class WeatherAppDBContext : IdentityDbContext<User>
    {
        public WeatherAppDBContext(DbContextOptions<WeatherAppDBContext> options) : base(options)
        {
        }
    }
}
