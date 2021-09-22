using Category.Standard.Abstracts;
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
    [Description("Duplicate Category")]
    public class DuplicateCategoryRule : AbstractRule, IRule
    {
        public DuplicateCategoryRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var item in DistributorCats.Where(x => !x.Category.SameText("AVOP")))
            {
                if (result.Any(x => x.Main.SameText(item.Category))) continue;

                var dupCats = DistributorCats.Where(x => x != item && x.Category.SameText(item.Category));
                if (dupCats.Count() <= 1) continue;

                result.Add(new DuplicateCategorySuggestion { Main = item.Category, Answers = dupCats.Select(x => x.Distributor).ToList() });
            }
            return result;
        }
    }
}
