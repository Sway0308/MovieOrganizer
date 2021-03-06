﻿using Category.Standard.Abstracts;
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
        public OneBracketRule(IList<Film> films, IList<DistributorCat> distributorCats) : base(films, distributorCats)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films.Where(x => x.Brackets.Count == 1))
            {
                var bracket = film.Brackets[0];
                if (bracket.Type != Configs.CategoryType.Identification)
                    continue;

                var iden = bracket.Text.RemoveCharToEmptyStr("(", ")");
                var sugs = new List<string>();
                var dists = DistributorCats.Where(x => iden.StartsWith(x.Category));
                foreach (var dist in dists)
                {
                    sugs.Add($"({dist.Distributor}){bracket.Text}");
                }

                result.Add(new FilmNameSuggestion { Film = film, Suggestions = sugs });
            }
            return result;
        }

        public void Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}
