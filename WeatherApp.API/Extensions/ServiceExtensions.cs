//using Microsoft.Extensions.DependencyInjection;

//namespace WeatherApp.API.Extensions
//{
//    public static class ServiceExtensions
//    {
//        public static void ConfigureCors(this IServiceCollection services) =>
//          services.AddCors(options =>
//          {
//              options.AddPolicy("CorsPolicy", builder =>
//                  builder.AllowAnyOrigin()
//                  .AllowAnyMethod()
//                  .AllowAnyHeader());
//          });

//        public static void ConfigureIISIntegration(this IServiceCollection services) =>
//            services.Configure<IISOptions>(options =>
//            {
//            });

//        public static void ConfigureIdentity(this IServiceCollection services)
//        {
//            var builder = services.AddIdentityCore<User, IdentityRole>(o =>
//            {
//                o.Password.RequireDigit = false;
//                o.Password.RequireLowercase = false;
//                o.Password.RequireNonAlphanumeric = false;
//                o.Password.RequireUppercase = false;
//                o.Password.RequiredLength = 6;
//                o.User.RequireUniqueEmail = true;
//            })
//              .AddEntityFrameworkStores<WeatherAppDBContext>()
//              .AddDefaultTokenProviders();
            
//        }

//        public static void ConfigureServices(this IServiceCollection services)
//        {
           
//        }
//    }
//}

