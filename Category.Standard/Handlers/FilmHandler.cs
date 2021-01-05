using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler : DirRecursiveHandler
    {
        private readonly string ExtensionPath = Path.Combine(BaseConstants.AppDataPath, "extension.json");

        public FilmHandler()
        {
            Directory.CreateDirectory(BaseConstants.AppDataPath);

            InitBrackets();
            InitDistributorCat();

            if (!File.Exists(ExtensionPath))
                Extensions = new List<string>();
            else
            {
                var json = File.ReadAllText(ExtensionPath);
                var exts = JsonConvert.DeserializeObject<IList<string>>(json);
                Extensions = new List<string>(exts);
            }
        }

        private IList<string> Extensions { get; }
        public IList<string> EmptyFileDirs { get; } = new List<string>();
        public IList<Film> FilmInfos { get; } = new List<Film>();

        protected override void BeforeRecusiveSearch(string path)
        {
            EmptyFileDirs.Clear();
            FilmInfos.Clear();
        }

        protected override void ProcessFiles(string path, IEnumerable<string> files)
        {
            if (!files.Any())
            {
                EmptyFileDirs.Add(path);
                return;
            }

            foreach (var file in files.Where(x => Extensions.Contains(Path.GetExtension(x))))
            {
                var model = ExtractFilmInfo(file);
                FilmInfos.Add(model);
            }
        }

        protected override void AfterRecusiveSearch(string path)
        {
            ExportBrackets();
            ExportDistributorCats();
        }
    }
}
