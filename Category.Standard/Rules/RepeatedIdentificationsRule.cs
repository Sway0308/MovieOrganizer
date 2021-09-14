using Category.Standard.Abstracts;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Category.Standard.Rules
{
    [Description("Repeated Identifications")]
    public class RepeatedIdentificationsRule : AbstractRule, IRule
    {
        public RepeatedIdentificationsRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films)
            {
                if (result.Any(x => x.Main.SameText(film.Identification)))
                    continue;

                var repeats = Films.Where(x => !string.IsNullOrEmpty(x.Identification) && film.Identification.SameText(x.Identification));
                if (repeats.Count() <= 1)
                    continue;

                var answers = new List<Film>();
                foreach (var item in repeats)
                {
                    if (repeats.Any(x => x != item && x.DirectoryPath.SameText(item.DirectoryPath)))
                        continue;

                    answers.Add(item);
                }

                if (answers.Count == 0)
                    continue;

                result.Add(new RepeatedIdentifications { Identification = film.Identification, FilmInfos = answers });
            }
            return result;
        }
    }
}
