using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Adaptors
{
    public class CatalogAdaptor
    {
        private string FilmPath => BaseConstants.FilmPath;
        private string DistributorCatPath => BaseConstants.DistributorCatPath;

        public CatalogAdaptor(string path) : base()
        {
            BaseConstants.SetExportPath(path);
            BaseConstants.LoadInfos(FilmPath, FilmInfos);
            BaseConstants.LoadInfos(DistributorCatPath, DistributorCats);
        }
        public IList<DistributorCat> DistributorCats { get; } = new List<DistributorCat>();
        public IList<Film> FilmInfos { get; } = new List<Film>();

        public IList<string> FindFilms(string keyword)
        {
            var result = FilmInfos.Where(x => x.FileName.Include(keyword));
            return result.Select(x => x.FilePath).ToList();
        }

        public string FindDistributor(string keyword)
        {
            var result = DistributorCats.Where(x => x.Category.Include(keyword));
            return result.FirstOrDefault()?.Distributor;
        }
    }
}
