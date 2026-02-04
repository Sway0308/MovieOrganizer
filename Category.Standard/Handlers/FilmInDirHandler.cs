using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Abstracts;
using Gatchan.Base.Standard.Base;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Category.Standard.Handlers
{
    public partial class FilmInDirHandler : DirRecursiveHandler
    {
        /// <summary>
        /// 是否匯出包含來源
        /// </summary>
        private readonly bool ExportAndIncludeSource = false;

        /// <summary>
        /// 是否為可識別的路徑格式
        /// </summary>
        private readonly bool IsRecognizedPath = false;
        /// <summary>
        /// 擴充檔名
        /// </summary>
        private readonly Extension Extensions;

        private readonly JsonFileHandler<ClassificationDefine> ClassificationDefineHandler = new JsonFileHandler<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
        private readonly JsonListFileHandler<ParserSetting> ParserSettingHandler = new ParserSettingFileHandler(BaseConstants.ParserSettingsPath);

        public FilmInDirHandler(bool exportAndIncludeSource, bool isRecognizedPath)
        {
            ExportAndIncludeSource = exportAndIncludeSource;
            IsRecognizedPath = isRecognizedPath;

            Extensions = BaseConstants.LoadInfo<Extension>(BaseConstants.ExtensionPath);
            BaseConstants.LoadInfos(BaseConstants.DistributorCatPath, DistributorCats);

            if (ParserSettingHandler.Items.Count == 0)
            {
                ParserSettingHandler.Items.Add(new ParserSetting("Default", @"^\((?<distributor>[^)]+)\)\((?<id>[^)]+)\)"));
                ParserSettingHandler.SaveItemsToJson();
            }
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

            foreach (var setting in ParserSettingHandler.Items)
            {
                if (string.IsNullOrWhiteSpace(setting.Pattern)) continue;
                try
                {
                    var regex = new Regex(setting.Pattern, RegexOptions.IgnoreCase);
                    var match = regex.Match(model.FileName);
                    if (match.Success)
                    {
                        var distGroup = match.Groups["distributor"];
                        var idGroup = match.Groups["id"];

                        if (distGroup != null && distGroup.Success)
                            model.Distributor = distGroup.Value;

                        if (idGroup != null && idGroup.Success)
                            model.Identification = idGroup.Value;

                        break;
                    }
                }
                catch { }
            }

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
                         from y in Extensions.FilmExtensions
                         where y.SameText(Path.GetExtension(x))
                         select x;
            return result;
        }

        protected override void AfterRecusiveSearch(string path)
        {
            #region Pipeline way

            foreach (var _ in BlockCollectionPhase4(BlockCollectionPhase3(BlockCollectionPhase2(BlockCollectionPhase1(FilmInfos)))))
            ;

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
            bool regexMatched = !string.IsNullOrEmpty(model.Distributor) && !string.IsNullOrEmpty(model.Identification);

            if (regexMatched)
            {
                // Sync Regex results to Brackets for UI consistency
                if (model.Brackets.Count > 0 && model.Brackets[0].Text.Contains(model.Distributor))
                {
                    model.Brackets[0].Type = CategoryType.Distributor;
                }
                
                if (model.Brackets.Count > 1 && model.Brackets[1].Text.Contains(model.Identification))
                {
                    model.Brackets[1].Type = CategoryType.Identification;
                }
            }

            if (!regexMatched)
            {
                if (model.Brackets.Count < 2)
                    return;

                var distributorBracket = model.Brackets[0];
                distributorBracket.Type = CategoryType.Distributor;
                model.Distributor = distributorBracket.Text;

                var identifyBracket = model.Brackets[1];
                identifyBracket.Type = CategoryType.Identification;
                model.Identification = identifyBracket.Text;
            }

            if (!IsRecognizedPath)
                return;

            var identify = model.Identification;
            string category;
            
            if (identify.StartsWith("(") && identify.Contains("-"))
            {
                var index = identify.IndexOf('-');
                if (index < 0) return;
                category = identify.Substring(1, index - 1);
            }
            else if (identify.Contains("-"))
            {
                 var index = identify.IndexOf('-');
                 if (index < 0) return; 
                 category = identify.Substring(0, index);
            }
            else 
            {
                return;
            }

            var distributor = model.Distributor.RemoveCharToEmptyStr("(", ")");

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
            BusinessFunc.ExportListToFile(ExtractHistoryFilmItems(), BaseConstants.HistoryFilmPath, true);
            BusinessFunc.ExportListToFile(EmptyFileDirs, BaseConstants.EmptyDirPath, ExportAndIncludeSource);
        }

        private IList<FilmItem> ExtractHistoryFilmItems()
        {
            var result = new List<FilmItem>();
            foreach (var film in FilmInfos)
            {
                var check = true;
                foreach (var item in BaseConstants.HistoryExcludeRules)
                {
                    string regexPattern = "^" + Regex.Escape(item)
                                      .Replace("*", ".*")
                                      .Replace("?", ".") + "$";

                    if (Regex.IsMatch(film.PureFileName, regexPattern, RegexOptions.IgnoreCase))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    result.Add(new FilmItem(film.FilePath, film.FileName));
            }
            return result;
        }
    }
}