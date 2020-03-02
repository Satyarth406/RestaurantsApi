using RestaurantsDomainLayer.HelperModels;
using RetaurantApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaurantApiServices.Services
{
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public Dictionary<string,PropertyMappingValue> mappings{ get; set; }

        public PropertyMapping(Dictionary<string, PropertyMappingValue> keyValuePairs)
        {
            mappings = keyValuePairs;
        }
    }
}
