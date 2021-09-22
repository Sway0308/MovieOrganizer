using Category.Standard.Interfaces;
using Category.Standard.Models;
using System.Collections.Generic;

namespace Category.Standard.Abstracts
{
    public abstract class AbstractRule
    {
        protected readonly ICatalog _Catalog;
        protected AbstractRule(ICatalog catalog)
        {
            _Catalog = catalog;
        }

        protected IReadOnlyList<Film> Films => _Catalog.FilmInfos;
        protected IReadOnlyList<DistributorCat> DistributorCats => _Catalog.DistributorCats;
    }
}
