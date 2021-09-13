using Category.Standard.Cache;
using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Adaptors
{
    public class CatalogAdaptor : ICatalog
    {
        private const int ExpirationTime = 60;
        private FilmFileHandler FilmFileHandler => CacheManager.GetOrCreate(CacheKey.FilmFileHandler, ExpirationTime, () => {
            return new FilmFileHandler(BaseConstants.FilmPath);
        });
        private DistributorCatFileHandler DistributorCatFileHandler => CacheManager.GetOrCreate(CacheKey.DistributorCatFileHandler, ExpirationTime, () => {
            return new DistributorCatFileHandler(BaseConstants.DistributorCatPath);
        });
        private EmptyDirFileHandler EmptyDirFileHandler => CacheManager.GetOrCreate(CacheKey.EmptyDirFileHandler, ExpirationTime, () => {
            return new EmptyDirFileHandler(BaseConstants.EmptyDirPath);
        });
        private ExtensionFileHandler ExtensionFileHandler => CacheManager.GetOrCreate(CacheKey.ExtensionFileHandler, ExpirationTime, () => {
            return new ExtensionFileHandler(BaseConstants.ExtensionPath);
        });
        private ClassificationDefineFileHandler ClassificationDefineFileHandler => CacheManager.GetOrCreate(CacheKey.ClassificationDefineFileHandler, ExpirationTime, () => {
            return new ClassificationDefineFileHandler(BaseConstants.ClassificationDefinePath);
        });

        public CatalogAdaptor(string path) : base()
        {
            BaseConstants.SetExportPath(path);
        }

        public IList<Film> FilmInfos => FilmFileHandler.Items;
        public IList<DistributorCat> DistributorCats => DistributorCatFileHandler.Items;
        public IList<string> EmptyDirs => EmptyDirFileHandler.Items;
        public Extension Extensions => ExtensionFileHandler.Item;
        public ClassificationDefine ClassificationDefine => ClassificationDefineFileHandler.Item;

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
            foreach (var value in Enum.GetNames(typeof(CacheKey)))
            {
                if (Enum.TryParse<CacheKey>(value, out var result))
                    CacheManager.DeleteCache(result);
            }
        }
    }
}
