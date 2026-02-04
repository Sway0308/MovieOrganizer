namespace FilmIndex.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NLog.LogManager.LoadConfiguration("NLog.config");
                var host = new FilmIndexHost();
                host.Start();
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
