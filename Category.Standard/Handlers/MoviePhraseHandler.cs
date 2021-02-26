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
            var filmCollector = new JsonListFileHandler<Film>(BaseConstants.FilmPath);
            var films = filmCollector.Items;

            var classDefineCollector = new JsonListFileHandler<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
            var classDefines = classDefineCollector.Items;

            ClassifyFilms(films, classDefines);
        }

        private void ClassifyFilms(IList<Film> films, IList<ClassificationDefine> classificationDefines)
        {
            var keywords = classificationDefines.SelectMany(x => x.Actors).Union(classificationDefines.SelectMany(x => x.Genres)).ToArray();

            var result = new List<MoviePhrase>();
            foreach (var film in films)
            {
                var model = new MoviePhrase { FilePath = film.FilePath, FileName = film.FileName };
                var wording = model.FileName.Replace(film.Distributor, string.Empty).Replace(film.Identification, string.Empty);


                var recogPhrases = new List<string>();
                var unrecogPhrases = new List<string> { wording };
                SplitRecognizedPhrase(keywords, recogPhrases, unrecogPhrases);
                model.Phrase.AddRange(recogPhrases);
                model.Phrase.AddRange(unrecogPhrases);
                result.Add(model);
            }

            var handler = new JsonListFileHandler<MoviePhrase>(BaseConstants.MoviePhrasePath);
            handler.Items.Clear();
            handler.Items.AddRange(result);
            handler.SaveItemsToJson();
        }

        private void SplitRecognizedPhrase(string[] keywords, List<string> recogPhrases, List<string> unrecogPhrases)
        {
            if (!unrecogPhrases.Any(x => keywords.Any(y => x.Contains(y))))
                return;

            var wording = unrecogPhrases.First(x => keywords.Any(y => y.SameText(x)));
            unrecogPhrases.Remove(wording);
            DoSplitRecognizedPhrase(wording, keywords, recogPhrases, unrecogPhrases);

            SplitRecognizedPhrase(keywords, recogPhrases, unrecogPhrases);
        }

        private void DoSplitRecognizedPhrase(string src, string[] keywords, List<string> recogPhrases, List<string> unrecogPhrases)
        {
            var allPhrases = src.Split(keywords, StringSplitOptions.RemoveEmptyEntries);

            recogPhrases.AddRange(allPhrases.Where(x => keywords.Any(y => x.Contains(y))));
            unrecogPhrases.AddRange(allPhrases.Except(recogPhrases));
        }
    }
}
