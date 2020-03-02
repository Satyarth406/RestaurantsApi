using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsDomainLayer.HelperModels
{
    public class PropertyMappingValue
    {
        public List<string> DestinationProperties { get; set; }
        public bool Revert { get; set; }

        public PropertyMappingValue(List<string> destinationProperties, bool revert=false)
        {
            DestinationProperties = destinationProperties;
            Revert = revert;
        }
    }
}
