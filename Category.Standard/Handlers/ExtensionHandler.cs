using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using Gatchan.Base.Standard.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class ExtensionHandler : DirRecursiveHandler
    {
        private string FilePath => BaseConstants.ExtensionPath;
        private readonly Extension Extensions;

        public ExtensionHandler()
        {
            Extensions = BaseConstants.LoadInfo<Extension>(FilePath);
        }

        protected override void ProcessFiles(string path, IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file).ToLower();
                Extensions.TempExtensions.Add(extension);
            }
        }

        protected override void AfterRecusiveSearch(string path)
        {
            foreach (var item in Extensions.TempExtensions.Distinct())
            {
                if (Extensions.FilmExtensions.Any(x => x.SameText(item)))
                    continue;

                if (Extensions.OtherExtensions.Any(x => x.SameText(item)))
                    continue;

                Extensions.OtherExtensions.Add(item);
            }

            Directory.CreateDirectory(BaseConstants.AppDataPath);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Extensions, Formatting.Indented));
        }
    }
}
