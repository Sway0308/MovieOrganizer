using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIndex.Host
{
    public static class BussinessFunc
    {
        private static ILoggerFactory _LoggerFactory;
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
