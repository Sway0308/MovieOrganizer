using Category.Standard.Abstracts;
using Category.Standard.Configs;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Category.Standard.Rules
{
    [Description("One Bracket")]
    public class OneBracketRule : AbstractRule, IRule
    {
        private readonly IList<IRuleModel> _OneBracketFilms = new List<IRuleModel>();

        public OneBracketRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            foreach (var film in Films.Where(x => x.Brackets.Count == 1))
            {
                var bracket = film.Brackets[0];
                if (bracket.Type != Configs.CategoryType.Identification)
                    continue;

                var iden = bracket.Text.RemoveCharToEmptyStr("(", ")");
                var sugs = new List<string>();
                var dists = DistributorCats.Where(x => iden.StartsWith(x.Category));
                var subject = film.FileName.Replace(bracket.Text, string.Empty).TrimStart(' ');
                foreach (var dist in dists)
                {
                    sugs.Add($"({dist.Distributor}){bracket.Text}{subject}");
                }

                _OneBracketFilms.Add(new FilmNameSuggestion { Film = film, Suggestions = sugs });
            }
            return _OneBracketFilms;
        }
    }
}
