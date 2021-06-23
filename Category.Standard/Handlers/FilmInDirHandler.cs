using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using Gatchan.Base.Standard.Base;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        private readonly JsonFileHandler<ClassificationDefine> ClassificationDefineHandler = new JsonFileHandler<ClassificationDefine>(BaseConstants.ClassificationDefinePath);

        public FilmInDirHandler(bool exportAndIncludeSource, bool isRecognizedPath)
        {
            ExportAndIncludeSource = exportAndIncludeSource;
            IsRecognizedPath = isRecognizedPath;
            
            Extensions = BaseConstants.LoadInfo<Extension>(BaseConstants.ExtensionPath);
            BaseConstants.LoadInfos(BaseConstants.DistributorCatPath, DistributorCats);
        }

        public IList<string> EmptyFileDirs { get; } = new List<string>();
        public IList<Film> FilmInfos { get; } = new List<Film>();
        public IList<DistributorCat> DistributorCats { get; } = new List<DistributorCat>();
        private ClassificationDefine ClassificationDefine => ClassificationDefineHandler.Item;

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
            var result = from x in files.AsParallel()
                         where Extensions.FilmExtensions.Contains(Path.GetExtension(x))
                         select x;
            return result;
        }

        protected override void AfterRecusiveSearch(string path)
        {
            #region Regular way

            //foreach (var model in FilmInfos)
            //{
            //    ClassifyDistributorAndCategoryFromFilmWithTwoBrackets(model);
            //    ClassifySingularDistributorOrCategoryFromNotRecognizedPath(model);
            //
            //    ClassifyGenres(model);
            //    ClassifyActors(model);
            //}

            #endregion

            #region Pipeline way

            foreach (var _ in BlockCollectionPhase4(BlockCollectionPhase3(BlockCollectionPhase2(BlockCollectionPhase1(FilmInfos))))) ;

            #endregion
        }

        private IEnumerable<Film> BlockCollectionPhase1(IEnumerable<Film> filmInfos)
        {
            var result = new BlockingCollection<Film>();
            Task.Run(() => {
                foreach (var model in filmInfos)
                {
                    ClassifyDistributorAndCategoryFromFilmWithTwoBrackets(model);
                    result.Add(model);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }

        private IEnumerable<Film> BlockCollectionPhase2(IEnumerable<Film> filmInfos)
        {
            var result = new BlockingCollection<Film>();
            Task.Run(() => {
                foreach (var model in filmInfos)
                {
                    ClassifySingularDistributorOrCategoryFromNotRecognizedPath(model);
                    result.Add(model);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }

        private IEnumerable<Film> BlockCollectionPhase3(IEnumerable<Film> filmInfos)
        {
            var result = new BlockingCollection<Film>();
            Task.Run(() => {
                foreach (var model in filmInfos)
                {
                    ClassifyGenres(model);
                    result.Add(model);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }

        private IEnumerable<Film> BlockCollectionPhase4(IEnumerable<Film> filmInfos)
        {
            var result = new BlockingCollection<Film>();
            Task.Run(() => {
                foreach (var model in filmInfos)
                {
                    ClassifyActors(model);
                    result.Add(model);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }

        private void ClassifyDistributorAndCategoryFromFilmWithTwoBrackets(Film model)
        {
            if (model.Brackets.Count < 2)
                return;

            var distributorBracket = model.Brackets[0];
            distributorBracket.Type = CategoryType.Distributor;
            model.Distributor = distributorBracket.Text;

            var identifyBracket = model.Brackets[1];
            identifyBracket.Type = CategoryType.Identification;
            model.Identification = identifyBracket.Text;

            if (!IsRecognizedPath)
                return;

            var identify = identifyBracket.Text;
            var index = identify.IndexOf('-');
            if (index < 0)
                return;

            var category = identify.Substring(1, index - 1);
            var distributor = distributorBracket.Text.RemoveCharToEmptyStr("(", ")");

            if (!DistributorCats.Any(x => x.Distributor.SameText(distributor) && x.Category.SameText(category)))
                DistributorCats.Add(new DistributorCat { Distributor = distributor, Category = category });
        }

        private void ClassifySingularDistributorOrCategoryFromNotRecognizedPath(Film model)
        {
            if (IsRecognizedPath)
                return;

            if (model.Brackets.Count != 1)
                return;

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

        private void ClassifyGenres(Film model)
        {
            var genres = from x in ClassificationDefine.Genres.AsParallel()
                         where model.FileName.IncludeText(x)
                         select x;

            foreach (var genre in genres)
            {
                model.Genres.Add(genre);
            }
        }

        private void ClassifyActors(Film model)
        {
            var actors = from x in ClassificationDefine.Actors.AsParallel()
                         where model.FileName.IncludeText(x)
                         select x;

            foreach (var genre in actors)
            {
                model.Actors.Add(genre);
            }
        }

        public void ExportJson()
        {
            BusinessFunc.ExportListToFile(DistributorCats, BaseConstants.DistributorCatPath, true);
            BusinessFunc.ExportListToFile(FilmInfos, BaseConstants.FilmPath, ExportAndIncludeSource);
            BusinessFunc.ExportListToFile(EmptyFileDirs, BaseConstants.EmptyDirPath, ExportAndIncludeSource);
        }
    }
}
