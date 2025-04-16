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
        private const int ExpirationSeconds = 300;
        private FilmFileHandler FilmFileHandler => CacheManager.GetOrCreate(CacheKey.FilmFileHandler, ExpirationSeconds, () => {
            return new FilmFileHandler(BaseConstants.FilmPath);
        });
        private HistoryFilmFileHandler HistoryFilmFileHandler => CacheManager.GetOrCreate(CacheKey.HistoryFilmFileHandler, ExpirationSeconds, () => {
            return new HistoryFilmFileHandler(BaseConstants.HistoryFilmPath);
        });
        private DistributorCatFileHandler DistributorCatFileHandler => CacheManager.GetOrCreate(CacheKey.DistributorCatFileHandler, ExpirationSeconds, () => {
            return new DistributorCatFileHandler(BaseConstants.DistributorCatPath);
        });
        private EmptyDirFileHandler EmptyDirFileHandler => CacheManager.GetOrCreate(CacheKey.EmptyDirFileHandler, ExpirationSeconds, () => {
            return new EmptyDirFileHandler(BaseConstants.EmptyDirPath);
        });
        private ExtensionFileHandler ExtensionFileHandler => CacheManager.GetOrCreate(CacheKey.ExtensionFileHandler, ExpirationSeconds, () => {
            return new ExtensionFileHandler(BaseConstants.ExtensionPath);
        });
        
        private ClassificationDefineFileHandler ClassificationDefineFileHandler => CacheManager.GetOrCreate(CacheKey.ClassificationDefineFileHandler, ExpirationSeconds, () => {
            return new ClassificationDefineFileHandler(BaseConstants.ClassificationDefinePath);
        });

        public CatalogAdaptor(string path) : base()
        {
            BaseConstants.SetExportPath(path);
        }

        public IReadOnlyList<Film> FilmInfos => FilmFileHandler.Items;
        public IReadOnlyList<FilmItem> HistoryFilmInfos => HistoryFilmFileHandler.Items;
        public IReadOnlyList<DistributorCat> DistributorCats => DistributorCatFileHandler.Items;
        public IReadOnlyList<string> EmptyDirs => EmptyDirFileHandler.Items;
        public Extension Extensions => ExtensionFileHandler.Item;
        public ClassificationDefine ClassificationDefine => ClassificationDefineFileHandler.Item;

        public IList<Film> FindFilms(string keyword)
        {
            var result = from x in FilmInfos.AsParallel()
                         where x.FileName.IncludeText(keyword) || x.DirectoryPath.IncludeText(keyword)
                         select x;

            return result.ToList();
        }

        public IList<FilmItem> FindHistoryFilms(string keyword)
        {
            var result = from x in HistoryFilmInfos.AsParallel()
                         where x.FileName.IncludeText(keyword) || x.FilePath.IncludeText(keyword)
                         select x;

            return result.ToList();
        }

        public string FindDistributor(string keyword)
        {
            var result = from x in DistributorCats.AsParallel()
                         where x.Category.SameText(keyword)
                         select x;
            return result.FirstOrDefault()?.Distributor;
        }

        public void SaveExtention()
        {
            ExtensionFileHandler.SaveItemToJson();
        }

        public void AddClassificationDefine(EClassificationDefine classificationDefine, string item)
        {
            if (string.IsNullOrEmpty(item))
                return;

            ClassificationDefine.AddItem(classificationDefine, item);
            SaveClassificationDefine();
        }

        public void DeleteClassificationDefine(EClassificationDefine classificationDefine, string item)
        {
            if (string.IsNullOrEmpty(item))
                return;

            ClassificationDefine.DeleteItem(classificationDefine, item);
            SaveClassificationDefine();
        }

        private void SaveClassificationDefine()
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
