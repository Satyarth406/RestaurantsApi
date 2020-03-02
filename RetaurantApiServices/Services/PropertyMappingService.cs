using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;
using RestaurantsDomainLayer.HelperModels;
using RetaurantApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaurantApiServices.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {

        public Dictionary<string, PropertyMappingValue> restaurantMappedProperties =
            new Dictionary<string, PropertyMappingValue>()
            {

            };

        public List<IPropertyMapping> PropertyMappings
            = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            PropertyMappings.Add(new PropertyMapping<RestaurantDto, Restaurant>(restaurantMappedProperties));
        }

        public Dictionary<string,PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var map = PropertyMappings.OfType<PropertyMapping<TSource, TDestination>>();
            if (map.Count() == 1)
            {
                return map.First().mappings;
            }
            throw new Exception("Cannot find the mapping for the given property");
        }
    }
}
