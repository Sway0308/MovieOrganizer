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

        protected IList<Film> Films => _Catalog.FilmInfos;
        protected IList<DistributorCat> DistributorCats => _Catalog.DistributorCats;
    }
}
