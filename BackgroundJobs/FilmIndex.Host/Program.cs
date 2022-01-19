using System.Threading.Tasks;

namespace FilmIndex.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new FilmIndexHost();
            await host.Start();
        }
    }
}
