using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantsDomainLayer.Entities;

namespace RestaurantsDataAccessLayer.DbContext
{
    public class RestaurantsDbContext : IdentityDbContext<ApplicationUser>
    {

        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> dbContextOptions) : base(dbContextOptions)
        {

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

    }
}
