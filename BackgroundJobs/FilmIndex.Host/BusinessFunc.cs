using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.IO;

namespace FilmIndex.Host
{
    public static class BussinessFunc
    {
        private static ILoggerFactory _LoggerFactory;
        private static IConfiguration _Configuration;

        public static IConfiguration GetConfiguration()
        {
            if (_Configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                _Configuration = builder.Build();
            }
            return _Configuration;
        }

        private static ILoggerFactory GetLogFactory()
        {
            if (_LoggerFactory == null)
            {
                _LoggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddNLog();
                });
            }
            return _LoggerFactory;
        }

        public static ILogger<T> GetLogger<T>()
        {
            return GetLogFactory().CreateLogger<T>();
        }
    }
}
