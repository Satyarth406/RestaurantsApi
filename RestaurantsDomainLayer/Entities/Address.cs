using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantsDomainLayer.Model
{
    public class Address
    {
        public Guid ID { get; set; }
        
        [Required,MaxLength(100)]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        
        [Required, MaxLength(100)]
        public string City { get; set; }
        public string Landmark { get; set; }

        [Required, MaxLength(100)]
        public string State { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }

        public Guid RestaurantID { get; set; }

        [ForeignKey("RestaurantID")]
        public Restaurant Restaurant { get; set; }
    }
}