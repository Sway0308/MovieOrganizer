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
    [Description("Distributer No Match")]
    public class DistributerNoMatchRule : AbstractRule, IRule
    {
        public DistributerNoMatchRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films.Where(x => !x.Distributor.IsEmpty() && !x.Identification.IsEmpty()))
            {
                if (result.Any(x => x.Main.SameText(film.FileName))) continue;

                var dis = film.Distributor.Replace("(", string.Empty).Replace(")", string.Empty);
                var tmpCat = film.Identification.Replace("(", string.Empty).Replace(")", string.Empty);
                var index = tmpCat.IndexOf('-');
                if (index < 0) continue;
                var cat = tmpCat.Substring(0, index);
                if (cat.SameText("AVOP")) continue;

                var a = DistributorCats.Where(x => cat.SameText(x.Category) && !dis.SameText(x.Distributor));
                if (!a.Any()) continue;

                var anses = new List<string>();
                var pureFileName = film.FileName.Replace(film.Distributor, string.Empty);
                foreach (var disCat in a)
                {
                    anses.Add($"({disCat.Distributor}){pureFileName}");
                }

                result.Add(new DistributerNoMatchSuggestion { Film = film, Answers = anses });
            }
            return result;
        }
    }
}
