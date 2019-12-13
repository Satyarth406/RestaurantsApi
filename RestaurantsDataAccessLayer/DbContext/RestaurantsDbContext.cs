using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using RestaurantsDomainLayer.Entities;

namespace RestaurantsDataAccessLayer.DbContext
{
    public class RestaurantsDbContext : IdentityDbContext<ApplicationUser>
    {
        //public static readonly LoggerFactory MyConsoleLoggerFactory = new LoggerFactory(
        //    new[]
        //    {
        //        new ConsoleLoggerProvider((category, level) =>
        //                category == DbLoggerCategory.Database.Command.Name && level ==LogLevel.Information
        //        ,true)
        //    });

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantsApiDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        //public DbSet<Address> UserAddresses { get; set; }
        //public DbSet<Address> RestaurantAddress { get; set; }

        public override int SaveChanges()
        {
            
            return base.SaveChanges();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Restaurant>()
            //    .HasOne<RestaurantAddress>()
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ApplicationUser>()
            //    .HasMany<UserAddress>()
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
