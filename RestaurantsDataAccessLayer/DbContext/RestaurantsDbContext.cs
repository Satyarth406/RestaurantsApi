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
            
            //builder.Entity<Restaurant>().HasData(
            //    new Restaurant(){Id = new Guid("c8baa505-acde-4394-acf0-441592897306"), Name  = "Bangalore rest 1",Rating = 4,Type = FoodType.American, AverageCost = 250,OwnerId = "",})
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
