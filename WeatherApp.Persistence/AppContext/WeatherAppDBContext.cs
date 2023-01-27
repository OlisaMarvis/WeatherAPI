using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using WeatherApp.Persistence.EntityConfigurations;

namespace WeatherApp.Persistence.AppContext
{
    public class WeatherAppDBContext : IdentityDbContext, IWeatherAppDBContext
    {
        public DbSet<User>? Users { get; set; }

        public WeatherAppDBContext(DbContextOptions<WeatherAppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfigurations());
        }

        async Task<int> IWeatherAppDBContext.SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
    

}
