using Category.Standard.Handlers;
using Category.Standard.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Category.Standard.Adaptors
{
    public class FilmAdaptor
    {
        private readonly FilmHandler Handler = new FilmHandler();

        public void Categorize(string path)
        {
            Handler.RecusiveSearch(path);
            Console.WriteLine($"Empty dir count: {Handler.EmptyFileDirs.Count}");
            Console.WriteLine($"All films count: {Handler.FilmInfos.Count}");
            if (Handler.FilmInfos.Count == 0)
                return;

            Console.WriteLine("Export films to csv? (Path/N)");
            var command = Console.ReadLine();
            if (string.Equals(command, "N", StringComparison.InvariantCultureIgnoreCase))
                return;
            
            ExportToCsv(command);
        }

        private void ExportToCsv(string csvPath)
        {
            var props = typeof(Film).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var title = string.Join(",", props.Select(x => x.Name));

            var content = new string[props.Length];
            var str = new StringBuilder();
            str.AppendLine(title);
            foreach (var item in Handler.FilmInfos)
            {                
                for(var i = 0; i < props.Length; i++)
                {
                    var prop = props[i];
                    var value = prop.GetValue(item, null);
                    content[i] = value.ToString();
                }

                str.AppendLine(string.Join(",", content));
            }

            var filePath = Path.Combine(csvPath, "film.csv");
            File.WriteAllText(filePath, str.ToString());
        }
    }
}
