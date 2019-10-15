using System;

namespace AuthorizationAndAuthorizationLibrary.Model
{
    public class FoodItem
    {
        public Guid ID{ get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public int Cost { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}