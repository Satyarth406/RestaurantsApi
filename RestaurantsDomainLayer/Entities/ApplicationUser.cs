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
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        //public List<Address> Addresses { get; set; }

    }
}
