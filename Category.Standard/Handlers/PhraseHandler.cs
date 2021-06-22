using Category.Standard.Configs;
using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Category.Standard.Handlers
{
    public class PhraseHandler
    {
        public void ClassifyAndExportDefines(IList<Film> filmInfos, ClassificationDefine classificationDefine)
        {
            var list = new List<Phrases>();
            foreach (var item in filmInfos)
            {
                var name = item.FileName;
                if (!string.IsNullOrEmpty(item.Distributor))
                    name = name.Replace(item.Distributor, string.Empty);
                if (!string.IsNullOrEmpty(item.Identification))
                    name = name.Replace(item.Identification, string.Empty);
                var allPhrases = name.Split(' ');
                foreach (var phrase in allPhrases)
                {
                    if (list.Any(x => x.Phrase.Equals(phrase, StringComparison.CurrentCultureIgnoreCase)))
                        continue;

                    var type = PhraseType.Undefined;
                    if (classificationDefine.Actors.Contains(phrase))
                        type = PhraseType.Actress;
                    else if (classificationDefine.Genres.Contains(phrase))
                        type = PhraseType.Subject;

                    list.Add(new Phrases { Phrase = phrase, PhraseType = type });
                }
            }

            var result = list.OrderBy(x => x.PhraseType).ThenBy(x => x.Phrase);
            BusinessFunc.ExportListToFile(result, BaseConstants.PhrasePath, false);
        }
    }
}
