using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public partial class FilmInDirHandler : DirRecursiveHandler
    {
        /// <summary>
        /// 匯出時是否保留來源資料
        /// </summary>
        private readonly bool ExportAndIncludeSource = false;

        /// <summary>
        /// 是否為受認可的範本路徑
        /// </summary>
        private readonly bool IsRecognizedPath = false;
        /// <summary>
        /// 副檔名資訊
        /// </summary>
        private readonly Extension Extensions;

        public FilmInDirHandler(bool exportAndIncludeSource, bool isRecognizedPath)
        {
            ExportAndIncludeSource = exportAndIncludeSource;
            IsRecognizedPath = isRecognizedPath;
            Extensions = BaseConstants.LoadInfo<Extension>(BaseConstants.ExtensionPath);
        }

        public IList<string> EmptyFileDirs { get; } = new List<string>();
        public IList<Film> FilmInfos { get; } = new List<Film>();
        public IList<DistributorCat> DistributorCats { get; } = new List<DistributorCat>();

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
        private Film ExtractFilmInfo(string file)
        {
            var model = new Film(file);
            var brackets = new List<Bracket>();
            ExtractBrackets(model.FileName, brackets);
            model.AddBrackets(brackets);
            return model;
        }

        private void ExtractBrackets(string fileName, IList<Bracket> brackets)
        {
            if (!fileName.StartsWith("(") || !fileName.Contains(")"))
                return;

            var leftBracket = fileName.IndexOf("(");
            var rightBracket = fileName.IndexOf(")");

            var innerText = fileName.Substring(leftBracket, rightBracket - leftBracket + 1);
            brackets.Add(new Bracket { Text = innerText });
            var nextFileName = fileName.Replace(innerText, string.Empty);
            ExtractBrackets(nextFileName, brackets);
        }

        private IEnumerable<string> GetValidFiles(IEnumerable<string> files)
        {
            if (Extensions.FilmExtensions.Count == 0)
                return files;
            return files.Where(x => Extensions.FilmExtensions.Contains(Path.GetExtension(x)));
        }

        protected override void AfterRecusiveSearch(string path)
        {
            ClassifyDistributorAndCategoryFromRecognizedPath();
            ClassifyDistributorAndCategoryFromNotRecognizedPath();
            ClassifySingularDistributorOrCategoryFromNotRecognizedPath();
        }

        private void ClassifyDistributorAndCategoryFromRecognizedPath()
        {
            if (!IsRecognizedPath)
                return;

            foreach (var model in FilmInfos.Where(x => x.Brackets.Count >= 2))
            {
                var (distributorBracket, identifyBracket) = ClassifyTwoBracketsModelIntoDistributorAndCategory(model);

                var distributor = distributorBracket.Text;
                var identify = identifyBracket.Text;
                var index = identify.IndexOf('-');
                if (index < 0)
                    continue;
                var category = identify.Substring(1, index - 1);
                distributor = distributor.RemoveCharToEmptyStr("(", ")");

                if (!DistributorCats.Any(x => x.Distributor.SameText(distributor) && x.Category.SameText(category)))
                    DistributorCats.Add(new DistributorCat { Distributor = distributor, Category = category });
            }
        }

        private void ClassifyDistributorAndCategoryFromNotRecognizedPath()
        {
            if (IsRecognizedPath)
                return;

            foreach (var model in FilmInfos.Where(x => x.Brackets.Count >= 2))
            {
                ClassifyTwoBracketsModelIntoDistributorAndCategory(model);
            }
        }

        private (Bracket distributor, Bracket identify) ClassifyTwoBracketsModelIntoDistributorAndCategory(Film model)
        {
            var distributor = model.Brackets[0];
            distributor.Type = CategoryType.Distributor;
            model.Distributor = distributor.Text;

            var identify = model.Brackets[1];
            identify.Type = CategoryType.Identification;
            model.Identification = identify.Text;
            return (distributor, identify);
        }

        private void ClassifySingularDistributorOrCategoryFromNotRecognizedPath()
        {
            if (IsRecognizedPath)
                return;

            foreach (var model in FilmInfos.Where(x => x.Brackets.Count == 1))
            {
                var bracket = model.Brackets[0];
                if (DistributorCats.Any(x => bracket.Text.IncludeText(x.Distributor)))
                {
                    bracket.Type = CategoryType.Distributor;
                    model.Distributor = bracket.Text;
                }
                else if (DistributorCats.Any(x => bracket.Text.IncludeText(x.Category)))
                {
                    bracket.Type = CategoryType.Identification;
                    model.Identification = bracket.Text;
                }
            }
        }

        public void ExportJson()
        {
            BusinessFunc.ExportListToFile(DistributorCats, BaseConstants.DistributorCatPath, ExportAndIncludeSource);
            BusinessFunc.ExportListToFile(FilmInfos, BaseConstants.FilmPath, ExportAndIncludeSource);
            BusinessFunc.ExportListToFile(EmptyFileDirs, BaseConstants.EmptyDirPath, ExportAndIncludeSource);
        }
    }
}
