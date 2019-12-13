using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

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
