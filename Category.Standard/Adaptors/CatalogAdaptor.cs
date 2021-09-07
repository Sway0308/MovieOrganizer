using Category.Standard.Cache;
using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Adaptors
{
    public class CatalogAdaptor
    {
        private JsonListFileHandler<Film> FilmFileHandler;
        private JsonListFileHandler<DistributorCat> DistributorCatFileHandler;
        private JsonListFileHandler<string> EmptyDirFileHandler;
        private JsonFileHandler<Extension> ExtensionFileHandler;
        private JsonFileHandler<ClassificationDefine> ClassificationDefineFileHandler;

        public CatalogAdaptor(string path, bool initOnCtor) : base()
        {
            BaseConstants.SetExportPath(path);
            if (initOnCtor)
                Init();
        }

        public IList<Film> FilmInfos => CacheManager.GetOrCreate<IList<Film>>("FilmInfos", x => { 
            return (new FilmFileHandler(BaseConstants.FilmPath)).Items;
        });
        public IList<DistributorCat> DistributorCats => CacheManager.GetOrCreate<IList<DistributorCat>>("DistributorCats", x => {
            return (new DistributorCatFileHandler(BaseConstants.DistributorCatPath)).Items;
        });
        public IList<string> EmptyDirs => CacheManager.GetOrCreate<IList<string>>("EmptyDirs", x => {
            return (new EmptyDirFileHandler(BaseConstants.EmptyDirPath)).Items;
        });
        public Extension Extensions => CacheManager.GetOrCreate("Extensions", x => {
            return (new ExtensionFileHandler(BaseConstants.ExtensionPath)).Item;
        });
        public ClassificationDefine ClassificationDefine => CacheManager.GetOrCreate("ClassificationDefine", x => {
            return (new ClassificationDefineFileHandler(BaseConstants.ClassificationDefinePath)).Item;
        });

        public IList<Film> FindFilms(string keyword)
        {
            var result = from x in FilmInfos.AsParallel()
                         where x.FileName.IncludeText(keyword)
                         select x;

            return result.ToList();
        }

        public string FindDistributor(string keyword)
        {
            var result = from x in DistributorCats.AsParallel()
                         where x.Category.IncludeText(keyword)
                         select x;
            return result.FirstOrDefault()?.Distributor;
        }

        public void SaveExtention()
        {
            ExtensionFileHandler.SaveItemToJson();
        }

        public void SaveClassificationDefine()
        {
            ClassificationDefineFileHandler.SaveItemToJson();
        }

        public void Init()
        {
            FilmFileHandler = new JsonListFileHandler<Film>(BaseConstants.FilmPath);
            DistributorCatFileHandler = new JsonListFileHandler<DistributorCat>(BaseConstants.DistributorCatPath);
            EmptyDirFileHandler = new JsonListFileHandler<string>(BaseConstants.EmptyDirPath);

            ExtensionFileHandler = new JsonFileHandler<Extension>(BaseConstants.ExtensionPath);
            ClassificationDefineFileHandler = new JsonFileHandler<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
        }
    }
}
