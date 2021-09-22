using Category.Standard.Abstracts;
using Category.Standard.Helpers;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Category.Standard.Rules
{
    [Description("Directory start with identity")]
    public class DirectoryStartWIthIdentityRule : AbstractRule, IRule
    {
        public DirectoryStartWIthIdentityRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films.Where(x => !string.IsNullOrEmpty(x.Identification) && x.DirectoryName.StartsWith(x.Identification)))
            {
                var suggestion = FilmHelper.GetSuggestFilmName(_Catalog, film.DirectoryName);
                var sugName = suggestion.suggestName.SameText(film.DirectoryName) ? string.Empty : suggestion.suggestName;

                var sugs = new List<string> { sugName };
                result.Add(new FilmDirectorySuggestion { Film = film, Answers = sugs });
            }

            var diss = DistributorCats.Select(x => "(" + x.Category);
            foreach (var film in Films.Where(x => string.IsNullOrEmpty(x.Identification)))
            {
                if (result.Any(x => (x as FilmDirectorySuggestion).Film.DirectoryPath == film.DirectoryPath))
                    continue;

                if (diss.Any(x => film.DirectoryName.StartsWith(x) && !film.DirectoryName.StartsWith(x + ")")))
                {
                    var suggestion = FilmHelper.GetSuggestFilmName(_Catalog, film.DirectoryName);
                    var sugName = suggestion.suggestName.SameText(film.DirectoryName) ? string.Empty : suggestion.suggestName;

                    var sugs = new List<string> { sugName };
                    result.Add(new FilmDirectorySuggestion { Film = film, Answers = sugs });
                }

                if (DistributorCats.Any(x => film.DirectoryName.StartsWith(x.Category + "-") && film.DirectoryName.Contains(" ")))
                {
                    var suggestion = FilmHelper.GetSuggestFilmName(_Catalog, film.DirectoryName);
                    var sugName = suggestion.suggestName.SameText(film.DirectoryName) ? string.Empty : suggestion.suggestName;

                    var sugs = new List<string> { sugName };
                    result.Add(new FilmDirectorySuggestion { Film = film, Answers = sugs });
                }
            }

            return result;
        }
    }
}
