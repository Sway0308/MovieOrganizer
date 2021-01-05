using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;

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
            Console.WriteLine($"Empty dir count: {Handler.EmptyFileDirs.Count}");
            Console.WriteLine($"All films count: {Handler.FilmInfos.Count}");
            Console.WriteLine();
            if (Handler.FilmInfos.Count == 0)
                return;

            Console.WriteLine("Export? (Y/N)");
            var command = Console.ReadLine();
            if (command.SameText("N"))
                return;

            Console.WriteLine("1. json, 2. csv (1/2)");
            var file = Console.ReadLine();
            if (file.SameText("1"))
                ExportToJson();
            else if (file.SameText("2"))
                ExportToCsv();
        }

        private void ExportToCsv()
        {
            var props = typeof(Film).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var title = string.Join(",", props.Select(x => x.Name));

            var str = new StringBuilder();
            str.AppendLine(title);
            foreach (var item in Handler.FilmInfos)
            {
                str.AppendLine(item.ToCsvFormat());
            }

            var filePath = Path.Combine(BaseConstants.AppDataPath, "film.csv");
            File.WriteAllText(filePath, str.ToString(), Encoding.UTF8);
            Console.WriteLine("done export csv");
            Console.WriteLine("============================================");
        }

        private void ExportToJson()
        {
            var str = JsonConvert.SerializeObject(Handler.FilmInfos, Formatting.Indented);
            var filePath = Path.Combine(BaseConstants.AppDataPath, "film.json");
            File.WriteAllText(filePath, str, Encoding.UTF8);
        }
    }
}
