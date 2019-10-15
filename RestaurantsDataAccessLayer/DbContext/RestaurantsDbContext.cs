using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RestaurantsDomainLayer.Model;

namespace RestaurantsDataAccessLayer.DbContext
{
    public class RestaurantsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
