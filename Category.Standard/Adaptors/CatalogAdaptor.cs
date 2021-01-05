using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Adaptors
{
    public class CatalogAdaptor
    {
        private readonly string FilmPath = Path.Combine(BaseConstants.AppDataPath, "film.json");
        private readonly string DistributorCatPath = Path.Combine(BaseConstants.AppDataPath, "DistributorCat.json");

        public CatalogAdaptor()
        {
            BaseConstants.LoadInfos(FilmPath, FilmInfos);
            BaseConstants.LoadInfos(DistributorCatPath, DistributorCats);
        }

        private IList<DistributorCat> DistributorCats { get; } = new List<DistributorCat>();
        public IList<Film> FilmInfos { get; } = new List<Film>();

        public string FindFilm(string keyword)
        {
            var result = FilmInfos.Where(x => x.FileName.Contains(keyword));
            return string.Join(Environment.NewLine, result.Select(x => x.FilePath));
        }

        public string FindDistributor(string keyword)
        {
            var result = DistributorCats.Where(x => x.Category.Contains(keyword));
            return string.Join(Environment.NewLine, result.Select(x => x.Distributor));
        }
    }
}
