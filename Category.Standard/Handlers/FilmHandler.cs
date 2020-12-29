using Category.Standard.Abstracts;
using Category.Standard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class FilmHandler : DirRecursiveHandler
    {
        private readonly string DirPath = AppDomain.CurrentDomain.BaseDirectory + "App_Data/";
        public FilmHandler()
        {
            Directory.CreateDirectory(DirPath);

            if (!File.Exists(FilePath))
                CategorizeBrackets = new List<Bracket>();
            else
            {
                var bracketJson = File.ReadAllText(FilePath);
                var brackets = JsonConvert.DeserializeObject<IList<Bracket>>(bracketJson);
                CategorizeBrackets = new List<Bracket>(brackets);
            }

            if (!File.Exists(ExtensionPath))
                Extensions = new List<string>();
            else
            {
                var json = File.ReadAllText(ExtensionPath);
                var brackets = JsonConvert.DeserializeObject<IList<string>>(json);
                Extensions = new List<string>(brackets);
            }
        }

        private string FilePath => DirPath + "Bracket.json";
        private string ExtensionPath => DirPath + "extension.json";
        private IList<Bracket> CategorizeBrackets { get; }
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

            foreach (var file in files)
            {
                var model = ExtractFilmInfo(file);
                FilmInfos.Add(model);
            }
        }

        protected override void AfterRecusiveSearch(string path)
        {
            IntergrateAndExportBrackets();
        }

        private Film ExtractFilmInfo(string file)
        {
            var model = new Film(file);
            var brackets = ExtractBrackets(model.FileName);
            model.AddBrackets(brackets);
            if (model.Brackets.Any(x => x.Type == Configs.CategoryType.Distributor))
            {
                model.Distributor = model.Brackets.First(x => x.Type == Configs.CategoryType.Distributor).Text;
            }

            if (model.Brackets.Any(x => x.Type == Configs.CategoryType.Identification))
            {
                model.Identification = model.Brackets.First(x => x.Type == Configs.CategoryType.Identification).Text;
            }

            if (model.Brackets.All(x => x.Type == Configs.CategoryType.Undefined))
            {
                if (model.Brackets.Count >= 2)
                {
                    model.Distributor = model.Brackets.ElementAt(0).Text;
                    model.Identification = model.Brackets.ElementAt(1).Text;
                }

                if (model.Brackets.Count == 1)
                {
                    var content = brackets.ElementAt(0).Text;
                    if (content.Contains("-"))
                        model.Identification = content;
                    else
                        model.Distributor = content;
                }
            }

            return model;
        }

        private IEnumerable<Bracket> ExtractBrackets(string fileName)
        {
            if (!fileName.Contains("(") || !fileName.Contains(")"))
                yield break;

            var leftBracket = fileName.IndexOf("(");
            var rightBracket = fileName.IndexOf(")");
            if (leftBracket < 0 || rightBracket < 0)
                yield break;

            var innerText = fileName.Substring(leftBracket + 1, rightBracket - leftBracket + 1);
            yield return DefineBracket(innerText);
            var nextFileName = fileName.Substring(rightBracket);
            ExtractBrackets(nextFileName);
        }

        private Bracket DefineBracket(string text)
        {
            var model = new Bracket { Text = text };
            var sourceBrackets = CategorizeBrackets.FirstOrDefault(x => x.Text.Equals(text, StringComparison.InvariantCultureIgnoreCase));
            if (sourceBrackets != null)
                model.Type = sourceBrackets.Type;
            return model;
        }

        private void IntergrateAndExportBrackets()
        {
            var brackets = FilmInfos.SelectMany(x => x.Brackets);
            foreach (var bracket in brackets)
            {
                if (!CategorizeBrackets.Any(x => x.Text.Equals(bracket.Text)))
                    CategorizeBrackets.Add(bracket);
            }

            if (CategorizeBrackets.Any())
            {
                var s = JsonConvert.SerializeObject(CategorizeBrackets);
                File.WriteAllText(s, FilePath);
            }
        }
    }
}
