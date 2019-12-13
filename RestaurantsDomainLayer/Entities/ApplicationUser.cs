using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsDomainLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            //Addresses = new List<Address>();
        }
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public string Name { get; set; }

        //public List<Address> Addresses { get; set; }

    }
}
