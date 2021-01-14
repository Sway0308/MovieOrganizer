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
    [Description("No Bracket But With Identification")]
    public class NoBracketButWithIdentificationRule : AbstractRule, IRule
    {
        public NoBracketButWithIdentificationRule(IList<Film> films, IList<DistributorCat> distributorCats) : base(films, distributorCats)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films.Where(x => x.Brackets.Count == 0))
            {
                var sugs = new List<string>();
                var dists = DistributorCats.Where(x => film.FileName.IncludeText(x.Category));
                foreach (var dist in dists)
                {
                    var index = film.FileName.IndexOf(dist.Category) + dist.Category.Length - 1;
                    if (film.FileName.Substring(index + 1, 1) != "-")
                        continue;

                    var idenNum = 0;
                    GetIdentificationNumber(film.FileName, index, ref idenNum);
                    var digits = Math.Floor(Math.Log10(idenNum) + 1);
                    if (digits <= 1)
                        continue;

                    sugs.Add($"({dist.Distributor})({dist.Category + "-" + idenNum})");
                }

                result.Add(new FilmNameSuggestion { Film = film, Suggestions = sugs });
            }
            return result;
        }

        private void GetIdentificationNumber(string filmName, int index, ref int idenNum)
        {
            var num = filmName.Substring(index, 1);
            if (int.TryParse(num, out var value))
            {
                idenNum = idenNum * 10 + value;
                index += 1;
                GetIdentificationNumber(filmName, index, ref idenNum);
            }
        }

        public void Solve()
        {
            throw new NotImplementedException();
        }
    }
}
