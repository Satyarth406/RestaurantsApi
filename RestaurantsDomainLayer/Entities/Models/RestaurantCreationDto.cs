namespace RestaurantsDomainLayer.Entities.Models
{
    public class RestaurantCreationDto
    {
        public string Name { get; set; }

        public FoodType Type { get; set; }

        public int AverageCost { get; set; }

        public int DeliveryTime { get; set; }

        public double Rating { get; set; }

        public virtual AddressCreationDto Location { get; set; }
    }
}
