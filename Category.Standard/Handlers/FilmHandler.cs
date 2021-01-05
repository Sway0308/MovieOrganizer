using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler : DirRecursiveHandler
    {
        private string ExtensionPath => BaseConstants.ExtensionPath;

        public FilmHandler()
        {
            Directory.CreateDirectory(BaseConstants.AppDataPath);

            InitBrackets();
            InitDistributorCat();
            Extensions = BaseConstants.LoadInfo<Extension>(ExtensionPath);
        }

        private Extension Extensions { get; }
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

            foreach (var file in files.Where(x => Extensions.FilmExtensions.Contains(Path.GetExtension(x))))
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
