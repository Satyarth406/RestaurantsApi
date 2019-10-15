using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsDomainLayer.Entities.Models
{
    public class AddressCreationDto
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

    }
}
