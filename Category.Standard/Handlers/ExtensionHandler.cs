using Category.Standard.Configs;
using Gatchan.Base.Standard.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class ExtensionHandler : DirRecursiveHandler
    {
        private readonly IList<string> Extensions = new List<string>();

        protected override void ProcessFiles(string path, IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                Extensions.Add(extension);
            }
        }

        protected override void AfterRecusiveSearch(string path)
        {
            var filePath = Path.Combine(BaseConstants.AppDataPath, "extension.json");
            File.WriteAllText(filePath, JsonConvert.SerializeObject(Extensions.Distinct(), Formatting.Indented));
        }
    }
}
