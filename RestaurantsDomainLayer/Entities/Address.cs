using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantsDomainLayer.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }
        public string Landmark { get; set; }

        [Required, MaxLength(100)]
        public string State { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }
        
    }
}
