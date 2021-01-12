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
    [Description("Contain Middle Bracket")]
    public class ContainMiddleBracketRule : AbstractRule, IRule
    {
        public ContainMiddleBracketRule(IList<Film> films, IList<DistributorCat> distributorCats) : base(films, distributorCats)
        {
        }

        public IList<FilmNameSuggestion> Find()
        {
            var result = new List<FilmNameSuggestion>();
            foreach (var film in Films.Where(x => x.FileName.IncludeText("[") && x.FileName.IncludeText("]")))
            {
                var allMidBrackContent = GetAllMiddleBracketContent(film.FileName);
                var ans = from mb in allMidBrackContent
                          from dist in DistributorCats
                          where mb.IncludeText(dist.Category)
                          select $"({dist.Distributor})({mb})";

                var sugs = new List<string>(ans.Distinct());
                result.Add(new FilmNameSuggestion { FilmInfo = film, SuggestNames = sugs });
            }

            return result;
        }

        private IEnumerable<string> GetAllMiddleBracketContent(string fileName)
        {
            var leftBracketIndex = fileName.IndexOf("[");
            var rightBracketIndex = fileName.IndexOf("]");
            if (leftBracketIndex < 0 || rightBracketIndex < 0)
                yield break;

            var content = fileName.Substring(leftBracketIndex, rightBracketIndex - leftBracketIndex + 1);
            var nextFileName = content.Replace($"[{content}]", string.Empty);
            GetAllMiddleBracketContent(nextFileName);
            yield return content;
        }

        public void Solve()
        {
            throw new NotImplementedException();
        }
    }
}
