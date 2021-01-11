using Category.Standard.Models;
using System.Collections.Generic;

namespace Category.Standard.Abstracts
{
    public abstract class AbstractRule
    {
        protected AbstractRule(IList<Film> films, IList<DistributorCat> distributorCats)
        {
            Films = new List<Film>(films);
            DistributorCats = new List<DistributorCat>(distributorCats);
        }

        protected IReadOnlyList<Film> Films { get; }
        protected IReadOnlyList<DistributorCat> DistributorCats { get; }
    }
}
