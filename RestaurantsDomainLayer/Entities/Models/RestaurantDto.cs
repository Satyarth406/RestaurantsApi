using System;

namespace RestaurantsDomainLayer.Entities.Models
{
    public class RestaurantDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public FoodType Type { get; set; }
        
        public int AverageCost { get; set; }
        
        public int DeliveryTime { get; set; }
        
        public double Rating { get; set; }
        
        public AddressDto Location { get; set; }
    }
}
