using System;
using Category.Standard.Adaptors;
using Category.Standard.Configs;
using Gatchan.Base.Standard.Base;
using Microsoft.Extensions.Configuration;

namespace FilmSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();
            var exportPath = config["ExportPath"];
            BaseConstants.SetExportPath(exportPath);
            Execute();
        }

        public static readonly CatalogAdaptor Adaptor = new CatalogAdaptor();

        private static void Execute()
        {
            Console.WriteLine("1. Search film?");
            Console.WriteLine("2. Search distributor?");
            var choice = Console.ReadLine();

            if (!choice.SameText("exit"))
                return;
            if (!choice.SameTextOr("1", "2"))
                Execute();

            Console.WriteLine("Search word?");
            var keyword = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var films = Adaptor.FindFilm(keyword);
                    Console.WriteLine(films);
                    break;
                case "2":
                    var distributors = Adaptor.FindDistributor(keyword);
                    Console.WriteLine(distributors);
                    break;
            }

            Console.WriteLine("============================================");
            Console.WriteLine();
            Execute();
        }
    }
}
