using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler
    {
        private readonly IList<DistributorCat> DistributorCats = new List<DistributorCat>();

        private void ClassifyDistributorAndCategory()
        {
            if (!IsRecognizedPath)
                return;

            foreach (var model in FilmInfos.Where(x => x.Brackets.Count >= 2))
            {
                var distributor = model.Brackets.ElementAt(0).Text;
                var identify = model.Brackets.ElementAt(1).Text;
                model.Distributor = distributor;
                model.Identification = identify;

                var index = identify.IndexOf('-');
                if (index < 0)
                    continue;
                var category = identify.Substring(0, index) + ")";
                if (!DistributorCats.Any(x => x.Distributor.SameText(distributor) && x.Category.SameText(category)))
                    DistributorCats.Add(new DistributorCat { Distributor = distributor, Category = category });
            }
        }
    }
}
