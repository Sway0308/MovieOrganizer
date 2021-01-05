using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler
    {
        private readonly string DistributorCatPath = Path.Combine(BaseConstants.AppDataPath, "DistributorCat.json");
        private IList<DistributorCat> DistributorCats { get; } = new List<DistributorCat>();

        private void InitDistributorCat()
        {
            DistributorCats.Clear();
            if (!File.Exists(DistributorCatPath))
                return;

            var json = File.ReadAllText(DistributorCatPath);
            var disCats = JsonConvert.DeserializeObject<IList<DistributorCat>>(json);
            foreach (var disCat in disCats)
            {
                DistributorCats.Add(disCat);
            }
        }

        private void ExportDistributorCats()
        {
            foreach (var model in FilmInfos.Where(x => x.Brackets.Count >= 2))
            {
                var distributor = model.Brackets.ElementAt(0).Text;
                var identify = model.Brackets.ElementAt(1).Text;
                var category = identify.Substring(0, identify.IndexOf('-'));
                if (!DistributorCats.Any(x => x.Distributor.SameText(distributor) && x.Category.SameText(category)))
                    DistributorCats.Add(new DistributorCat { Distributor = distributor, Category = category });
            }

            if (DistributorCats.Any())
            {
                var s = JsonConvert.SerializeObject(DistributorCats, Formatting.Indented);
                File.WriteAllText(DistributorCatPath, s);
            }
        }
    }
}
