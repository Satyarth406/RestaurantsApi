using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantsDomainLayer.Model
{
    public class FoodItem
    {
        [Key]
        public Guid ID{ get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }
        //public string Image { get; set; }
        public int Cost { get; set; }

        public Guid RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }
    }
}