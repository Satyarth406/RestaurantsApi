using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantsDomainLayer.Model;

namespace RestaurantsDataAccessLayer.DbContext
{
    public class RestaurantsDbContext : IdentityDbContext<IdentityUser>
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
