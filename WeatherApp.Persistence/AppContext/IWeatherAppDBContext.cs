using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.AppContext
{
    public interface IWeatherAppDBContext
    {
        DbSet<User>? Users { get; set; }
        Task<int> SaveChanges();
    }
}
