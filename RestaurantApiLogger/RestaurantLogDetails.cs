using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RestaurantApiLogger
{
    public class RestaurantLogDetails
    {
        public RestaurantLogDetails()
        {
            Timestamp = DateTime.Now;
            AdditionalData = new Dictionary<string, object>();
        }
        public DateTimeOffset Timestamp { get; private set; }
        public string Message { get; set; }

        public string Location { get; set; }
        public string Layer { get; set; }
        public string Product { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
       
        public string CorrelationId { get; set; }
        public long? TimeElapsed { get; set; }
        public Exception Exception{ get; set; }
        public Dictionary<string,object> AdditionalData { get; set; }
    }
}
