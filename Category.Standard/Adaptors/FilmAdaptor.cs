using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using Gatchan.Base.Standard.Base;
using System;

namespace Category.Standard.Adaptors
{
    public class FilmAdaptor : IServiceAdaptor
    {
        private readonly FilmHandler Handler = new FilmHandler();

        public void Execute(string inputParam)
        {
            Categorize(inputParam);
        }

        private void Categorize(string path)
        {
            Handler.RecusiveSearch(path);
            if (Handler.FilmInfos.Count == 0)
            {
                Console.WriteLine($"No films");
                return;
            }

            Console.WriteLine("Export? (Y/N)");
            var command = Console.ReadLine();
            if (!command.SameText("Y"))
                return;

            ExportToJson();
        }

        private void ExportToJson()
        {
            Handler.ExportJson();
        }
    }
}
