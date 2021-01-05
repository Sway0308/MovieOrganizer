using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler : DirRecursiveHandler
    {
        private readonly Extension Extensions;

        public FilmHandler()
        {
            InitBrackets();
            InitDistributorCat();
            Extensions = BaseConstants.LoadInfo<Extension>(ExtensionPath);
        }

        private string ExtensionPath => BaseConstants.ExtensionPath;
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

            foreach (var file in GetValidFiles(files))
            {
                var model = ExtractFilmInfo(file);
                FilmInfos.Add(model);
            }
        }

        private IEnumerable<string> GetValidFiles(IEnumerable<string> files)
        {
            if (Extensions.FilmExtensions.Count == 0)
                return files;
            return files.Where(x => Extensions.FilmExtensions.Contains(Path.GetExtension(x)));
        }

        public void ExportJson()
        {
            ExportBrackets();
            ExportDistributorCats();
            ExportFilmInfo();
            ExportEmptyDirs();
        }

        private void ExportEmptyDirs()
        {
            AppendList(EmptyFileDirs, BaseConstants.EmptyDirPath);
        }

        private void ExportFilmInfo()
        {
            AppendList(FilmInfos, BaseConstants.FilmPath);
        }

        private void AppendList<T>(IList<T> items, string path)
        {
            var sources = new List<T>();
            BaseConstants.LoadInfos(path, sources);
            foreach (var item in items)
            {
                if (!sources.Any(x => x.Equals(item)))
                    sources.Add(item);
            }

            var str = JsonConvert.SerializeObject(sources, Formatting.Indented);
            File.WriteAllText(path, str, Encoding.UTF8);
        }
    }
}
