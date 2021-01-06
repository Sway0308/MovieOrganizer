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
        /// <summary>
        /// 匯出時是否保留來源資料
        /// </summary>
        private readonly bool ExportAndIncludeSource = false;

        /// <summary>
        /// 是否為受認可的範本路徑
        /// </summary>
        private bool IsRecognizedPath = false;
        /// <summary>
        /// 副檔名資訊
        /// </summary>
        private readonly Extension Extensions;

        public FilmHandler(bool exportAndIncludeSource, bool isRecognizedPath)
        {
            ExportAndIncludeSource = exportAndIncludeSource;
            IsRecognizedPath = isRecognizedPath;
            Extensions = BaseConstants.LoadInfo<Extension>(BaseConstants.ExtensionPath);
        }

        public IList<string> EmptyFileDirs { get; } = new List<string>();
        public IList<Film> FilmInfos { get; } = new List<Film>();

        protected override void BeforeRecusiveSearch(string path)
        {
            EmptyFileDirs.Clear();
            FilmInfos.Clear();
        }

        protected override void ProcessFiles(string path, IEnumerable<string> files)
        {
            if (!files.Any() && !Directory.EnumerateDirectories(path).Any())
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

        protected override void AfterRecusiveSearch(string path)
        {
            ClassifyDistributorAndCategory();
        }

        public void ExportJson()
        {
            ExportList(DistributorCats, BaseConstants.DistributorCatPath);
            ExportList(FilmInfos, BaseConstants.FilmPath);
            ExportList(EmptyFileDirs, BaseConstants.EmptyDirPath);
        }

        private void ExportList<T>(IEnumerable<T> items, string path)
        {
            var sources = new List<T>();
            if (ExportAndIncludeSource)
            {
                BaseConstants.LoadInfos(path, sources);
            }

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
