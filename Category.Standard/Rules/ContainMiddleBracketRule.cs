using Category.Standard.Abstracts;
using Category.Standard.Configs;
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
        public ContainMiddleBracketRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films.Where(x => x.FileName.IncludeText("[") && x.FileName.IncludeText("]")))
            {
                var sugs = new List<string> { film.FileName.Replace("[", "(").Replace("]", ")") };
                result.Add(new FilmNameSuggestion { Film = film, Suggestions = sugs });
            }
            return result;
        }
    }
}
