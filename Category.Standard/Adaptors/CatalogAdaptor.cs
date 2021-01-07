using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Adaptors
{
    public class CatalogAdaptor
    {
        public CatalogAdaptor(string path) : base()
        {
            BaseConstants.SetExportPath(path);
            BaseConstants.LoadInfos(BaseConstants.FilmPath, FilmInfos);
            BaseConstants.LoadInfos(BaseConstants.DistributorCatPath, DistributorCats);
            Extensions = BaseConstants.LoadInfo<Extension>(BaseConstants.ExtensionPath);
            BaseConstants.LoadInfos(BaseConstants.EmptyDirPath, EmptyDirs);
            BaseConstants.LoadInfos(BaseConstants.BracketPath, Brackets);
            ClassificationDefine = BaseConstants.LoadInfo<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
        }

        public IList<DistributorCat> DistributorCats { get; } = new List<DistributorCat>();
        public IList<Film> FilmInfos { get; } = new List<Film>();
        public Extension Extensions { get; }
        public IList<string> EmptyDirs { get; } = new List<string>();
        public IList<Bracket> Brackets { get; } = new List<Bracket>();
        public ClassificationDefine ClassificationDefine { get; }

        public IList<Film> FindFilms(string keyword)
        {
            var result = FilmInfos.Where(x => x.FileName.IncludeText(keyword));
            return result.ToList();
        }

        public string FindDistributor(string keyword)
        {
            var result = DistributorCats.Where(x => x.Category.IncludeText(keyword));
            return result.FirstOrDefault()?.Distributor;
        }
    }
}
