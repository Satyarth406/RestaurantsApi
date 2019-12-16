using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using RestaurantsDomainLayer.Entities;

namespace RestaurantsDataAccessLayer.DbContext
{
    public class RestaurantsDbContext : IdentityDbContext<ApplicationUser>
    {

        public static readonly LoggerFactory MyLoggerFactory =
            new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category,level)=> category == DbLoggerCategory.Database.Command.Name
                                                             && level == LogLevel.Information, true)
            });

        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Restaurant>().HasData(new Restaurant()
            {
                Id = new Guid("2e17540f-f12f-4ba6-8263-7ca90ad9add5"),
                Name = "Bangalore Restau 1",
                AverageCost = 250,
                OwnerId = "4eb7727c-8b24-4f7f-b16f-ba885cd9c925",
                Rating = 4,
                Type = FoodType.American
            });

            builder.Entity<Address>().HasData(new Address()
            {
                Id = new Guid("36010404-a2c5-4179-a4fb-a5bc28fdbdbf"),
                Line1 = "unitech pearl yellukunte hosapalya",
                Line2 = "main road hsr layout",
                Landmark = "hsr",
                City = "Bangalore",
                State = "Karnataka",
                Country = "India",
            });

          
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
