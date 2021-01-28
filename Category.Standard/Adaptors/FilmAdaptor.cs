using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using Gatchan.Base.Standard.Base;
using System;
using System.IO;

namespace Category.Standard.Adaptors
{
    public class FilmAdaptor : IServiceAdaptor
    {
        private readonly FilmInDirHandler Handler = new FilmInDirHandler(false, true);

        public void Execute(string inputParam)
        {
            Categorize(inputParam);
        }

        private void Categorize(string path)
        {
            Directory.CreateDirectory(BaseConstants.AppDataPath);
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

            Handler.ExportJson();
        }
    }
}
