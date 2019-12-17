using System;
using System.Linq;
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
            var entities = builder.Model.GetEntityTypes().ToList();
            for (int i = 0; i < entities.Count(); i++)
            {
                builder.Entity(entities[i].Name).Property<DateTimeOffset>("Created");
                builder.Entity(entities[i].Name).Property<DateTimeOffset>("LastModified");
            }

           
            
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            var timeStamp = DateTimeOffset.Now;
            var entries = ChangeTracker.Entries()
                .Where(e => (e.State == EntityState.Modified || e.State == EntityState.Added) && !e.Metadata.IsOwned() ).ToList();
            for (int i = 0; i < entries.Count(); i++)
            {
                entries[i].Property("LastModified").CurrentValue = timeStamp;
                if (entries[i].State == EntityState.Added)
                {
                    entries[i].Property("Created").CurrentValue = timeStamp;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
