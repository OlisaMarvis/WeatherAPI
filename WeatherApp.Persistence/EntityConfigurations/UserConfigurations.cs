using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.EntityConfigurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();

            builder.HasData(
                new User
                {
                    UserId = new Guid(Guid.NewGuid().ToString()),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "olisamarvis@gmail.com"
                },
                new User
                {
                    UserId = new Guid(Guid.NewGuid().ToString()),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "olisamarvis@gmail.com"
                });
        }

    }
}
