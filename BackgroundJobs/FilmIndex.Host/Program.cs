namespace FilmIndex.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new FilmIndexHost();
            host.Start();
        }
    }
}
