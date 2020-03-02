using RestaurantsDomainLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantsDomainLayer.Entities
{
    public class Cart
    {
        public string UserId { get; set; }

        public List<ItemandQuantity> FoodItemsAndQuantity { get; set; }


    }
}
