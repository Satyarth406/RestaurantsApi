using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RestaurantApiLogger
{
    public class PerformanceLog
    {
        private readonly Stopwatch _stopwatch;
        private readonly RestaurantLogDetails _restaurantLogDetails;

        public PerformanceLog(string name,string userId, string userName,
            string location, string layer, string product,Dictionary<string,object> additionalInfo)
        {
            _restaurantLogDetails = new RestaurantLogDetails()
            {
                Message = name,
                UserId = userId,
                UserName = userName,
                Location = location,
                Layer = layer,
                Product = product
            };
            foreach (var additional in additionalInfo)
            {
                _restaurantLogDetails.AdditionalData.Add(additional.Key,additional.Value);
            }
            _stopwatch = Stopwatch.StartNew();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            _restaurantLogDetails.TimeElapsed = _stopwatch.ElapsedMilliseconds;
            Logger.WritePerformance(_restaurantLogDetails);
        }
    }
}
