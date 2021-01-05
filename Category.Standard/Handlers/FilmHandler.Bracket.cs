using Category.Standard.Configs;
using Category.Standard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler
    {
        private readonly string BracketPath = Path.Combine(BaseConstants.AppDataPath, "Bracket.json");

        private IList<Bracket> Brackets { get; } = new List<Bracket>();

        private void InitBrackets()
        {
            Brackets.Clear();
            if (!File.Exists(BracketPath))
                return;
            
            var json = File.ReadAllText(BracketPath);
            var brackets = JsonConvert.DeserializeObject<IList<Bracket>>(json);
            foreach (var bracket in brackets)
            {
                Brackets.Add(bracket);
            }
        }

        private Film ExtractFilmInfo(string file)
        {
            var model = new Film(file);
            var brackets = ExtractBrackets(model.FileName);
            model.AddBrackets(brackets);
            if (model.Brackets.Any(x => x.Type == CategoryType.Distributor))
            {
                model.Distributor = model.Brackets.First(x => x.Type == CategoryType.Distributor).Text;
            }

            if (model.Brackets.Any(x => x.Type == CategoryType.Identification))
            {
                model.Identification = model.Brackets.First(x => x.Type == CategoryType.Identification).Text;
            }

            if (model.Brackets.All(x => x.Type == CategoryType.Undefined))
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

            var innerText = fileName.Substring(leftBracket, rightBracket - leftBracket + 1);
            yield return DefineBracket(innerText);
            var nextFileName = fileName.Replace(innerText, string.Empty);
            ExtractBrackets(nextFileName);
        }

        private Bracket DefineBracket(string text)
        {
            var model = new Bracket { Text = text };
            var sourceBrackets = Brackets.FirstOrDefault(x => x.Text.Equals(text, StringComparison.InvariantCultureIgnoreCase));
            if (sourceBrackets != null)
                model.Type = sourceBrackets.Type;
            return model;
        }

        private void ExportBrackets()
        {
            var brackets = FilmInfos.SelectMany(x => x.Brackets).OrderByDescending(x => x.Type).ThenBy(x => x.Text);
            foreach (var bracket in brackets)
            {
                if (!Brackets.Any(x => x.Text.Equals(bracket.Text)))
                    Brackets.Add(bracket);
            }

            if (Brackets.Any())
            {
                var s = JsonConvert.SerializeObject(Brackets, Formatting.Indented);
                File.WriteAllText(BracketPath, s);
            }
        }
    }
}
