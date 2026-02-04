using NLog;

namespace FilmIndex.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LogManager.Setup().LoadConfigurationFromFile("NLog.config");
                var host = new FilmIndexHost();
                host.Start();
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
