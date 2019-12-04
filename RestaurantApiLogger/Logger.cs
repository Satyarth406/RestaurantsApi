using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Serilog;
using Serilog.Events;

namespace RestaurantApiLogger
{
    public static class Logger
    {
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _performanceLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static Logger()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "RestaurantApiLog");
            Directory.CreateDirectory(specificFolder);

            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(specificFolder, "usageLogger.txt"))
                .CreateLogger();
            _performanceLogger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(specificFolder, "performanceLogger.txt"))
                .CreateLogger();
            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(specificFolder, "errorLogger.txt"))
                .CreateLogger();
            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(specificFolder, "diagnosticLogger.txt"))
                .CreateLogger();
        }

        public static void WriteUsage(RestaurantLogDetails restaurantLogDetails)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@RestaurantLogDetails}",restaurantLogDetails);
        }

        public static void WritePerformance(RestaurantLogDetails restaurantLogDetails)
        {
            _performanceLogger.Write(LogEventLevel.Information, "{@RestaurantLogDetails}", restaurantLogDetails);
        }

        public static void WriteError(RestaurantLogDetails restaurantLogDetails)
        {
            _errorLogger.Write(LogEventLevel.Information, "{@RestaurantLogDetails}", restaurantLogDetails);
        }

        public static void WriteDiagnostic(RestaurantLogDetails restaurantLogDetails)
        {
            _diagnosticLogger.Write(LogEventLevel.Information, "{@RestaurantLogDetails}", restaurantLogDetails);
        }
    }
}
