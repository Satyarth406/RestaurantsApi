using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsDomainLayer.HelperModels
{
    public class RestaurantParams
    {
        private int _pageSize = 25;

        //public int Rating { get; set; }

        public int PageNumber { get; set; } = 1;

        private const int maxRestaurantPageSize = 25;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value >= maxRestaurantPageSize ? maxRestaurantPageSize : value;
            }
        }

    }
}
