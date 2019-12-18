using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RestaurantsDomainLayer.Entities
{
    /// <summary>
    /// Resturant with Id, Name
    /// </summary>
    public class Restaurant
    {
        public Restaurant()
        {
            FoodItems = new List<FoodItem>();
            Location = new Address();
        }

        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
        public FoodType Type { get; set; }

        [Range(0.0,Double.MaxValue)]
        public double AverageCost { get; set; }

        [Range(1,5)]
        public double Rating { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }

        public List<FoodItem> FoodItems { get; set; }
        
        public Address Location { get; set; }

    }
}
