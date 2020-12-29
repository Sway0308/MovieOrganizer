using MovieOrganizer.Abstracts;
using MovieOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieOrganizer.Handlers
{
    public class FilmHandler : DirRecursiveHandler
    {
        public IList<string> EmptyFileDirs { get; } = new List<string>();
        public IList<FilmModel> Films { get; } = new List<FilmModel>();

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
                Films.Add(model);
            }            
        }

        private FilmModel ExtractFilmInfo(string file)
        {
            var model = new FilmModel(file);
            var brackets = ExtractBrackets(model.FileName);
            var counts = brackets.Count();
            if (counts >= 2)
            {
                model.Distributor = brackets.ElementAt(0);
                model.Identification = brackets.ElementAt(1);
            }

            if (counts == 1)
            {
                var content = brackets.ElementAt(0);
                if (content.Contains("-"))
                    model.Identification = content;
                else
                    model.Distributor = content;
            }

            return model;
        }

        private IEnumerable<string> ExtractBrackets(string fileName)
        {
            if (!fileName.Contains("(") || !fileName.Contains(")"))
                yield break;

            var leftBracket = fileName.IndexOf("(");
            var rightBracket = fileName.IndexOf(")");
            if (leftBracket < 0 || rightBracket < 0)
                yield break;

            var innerText = fileName.Substring(leftBracket + 1, rightBracket - leftBracket + 1);
            yield return innerText;
            var nextFileName = fileName.Substring(rightBracket);
            ExtractBrackets(nextFileName);
        }
    }
}
