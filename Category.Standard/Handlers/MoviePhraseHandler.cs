using Category.Standard.Configs;
using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gatchan.Base.Standard.Base;

namespace Category.Standard.Handlers
{
    public class MoviePhraseHandler
    {
        public void Analyze()
        {
            BaseConstants.SetExportPath(@"\\as-204te\Sway\FilmDb");

            var filmCollector = new JsonListFileHandler<Film>(BaseConstants.FilmPath);
            var films = filmCollector.Items;

            var classDefineCollector = new JsonFileHandler<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
            var classDefines = classDefineCollector.Item;

            ClassifyFilms(films, classDefines);
        }

        private void ClassifyFilms(IList<Film> films, ClassificationDefine classificationDefines)
        {
            var keywords = classificationDefines.Actors.Union(classificationDefines.Genres).ToArray();

            var result = new List<MoviePhrase>();
            foreach (var film in films.Where(x => x.Distributor.Length != 0 && x.Identification.Length != 0))
            {
                var model = new MoviePhrase { FilePath = film.FilePath, FileName = film.FileName };
                var wording = model.FileName.Replace(film.Distributor, string.Empty).Replace(film.Identification, string.Empty);

                var recogPhrases = new List<string>();
                var unrecogPhrases = new List<string> { wording };
                SplitRecognizedPhrase(keywords, recogPhrases, unrecogPhrases);
                model.RecogPhrase.AddRange(recogPhrases);
                model.UnrecogPhrase.AddRange(unrecogPhrases);
                result.Add(model);
            }

            var handler = new JsonListFileHandler<MoviePhrase>(BaseConstants.MoviePhrasePath);
            handler.Items.Clear();
            handler.Items.AddRange(result);
            handler.SaveItemsToJson();
        }

        private void SplitRecognizedPhrase(string[] keywords, List<string> recogPhrases, List<string> unrecogPhrases)
        {
            var wording = unrecogPhrases.FirstOrDefault(x => keywords.Any(y => x.Contains(y)));
            if (wording == null)
                return;
            
            unrecogPhrases.Remove(wording);
            DoSplitRecognizedPhrase(wording, keywords, recogPhrases, unrecogPhrases);

            SplitRecognizedPhrase(keywords, recogPhrases, unrecogPhrases);
        }

        private void DoSplitRecognizedPhrase(string src, string[] keywords, List<string> recogPhrases, List<string> unrecogPhrases)
        {
            var allPhrases = src.Split(keywords, StringSplitOptions.RemoveEmptyEntries);

            recogPhrases.AddRange(keywords.Where(x => src.Contains(x)));
            unrecogPhrases.AddRange(allPhrases.Except(recogPhrases));
        }
    }
}
