using Category.Standard.Abstracts;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Rules
{
    public class RepeatedIdentificationsRule : AbstractRule, IRule
    {
        public RepeatedIdentificationsRule(IList<Film> films, IList<DistributorCat> distributorCats) : base(films, distributorCats)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films)
            {
                var repeats = Films.Where(x => film.Identification.SameText(x.Identification) && !film.FilePath.SameText(x.FilePath));
                if (repeats.Any())
                    result.Add(new RepeatedIdentifications { Identification = film.Identification, FilmInfos = repeats.ToList() });
            }
            return result;
        }

        public void Solve()
        {
            throw new NotImplementedException();
        }
    }
}
