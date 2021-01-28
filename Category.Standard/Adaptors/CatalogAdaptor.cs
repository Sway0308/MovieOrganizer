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
        private readonly JsonListFileHandler<Film> FilmFileHandler;
        private readonly JsonListFileHandler<DistributorCat> DistributorCatFileHandler;
        private readonly JsonListFileHandler<string> EmptyDirFileHandler;
        private readonly JsonListFileHandler<Bracket> BracketFileHandler;
        private readonly JsonFileHandler<Extension> ExtensionFileHandler;
        private readonly JsonFileHandler<ClassificationDefine> ClassificationDefineFileHandler;

        public CatalogAdaptor(string path) : base()
        {
            BaseConstants.SetExportPath(path);

            FilmFileHandler = new JsonListFileHandler<Film>(BaseConstants.FilmPath);
            DistributorCatFileHandler = new JsonListFileHandler<DistributorCat>(BaseConstants.DistributorCatPath);
            EmptyDirFileHandler = new JsonListFileHandler<string>(BaseConstants.EmptyDirPath);
            BracketFileHandler = new JsonListFileHandler<Bracket>(BaseConstants.BracketPath);

            ExtensionFileHandler = new JsonFileHandler<Extension>(BaseConstants.ExtensionPath);
            ClassificationDefineFileHandler = new JsonFileHandler<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
        }

        public IList<Film> FilmInfos => FilmFileHandler.Items;
        public IList<DistributorCat> DistributorCats => DistributorCatFileHandler.Items;
        public IList<string> EmptyDirs => EmptyDirFileHandler.Items;
        public IList<Bracket> Brackets => BracketFileHandler.Items;
        public Extension Extensions => ExtensionFileHandler.Item;
        public ClassificationDefine ClassificationDefine => ClassificationDefineFileHandler.Item;

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

        public void SaveExtention()
        {
            ExtensionFileHandler.SaveItemToJson();
        }

        public void SaveClassificationDefine()
        {
            ClassificationDefineFileHandler.SaveItemToJson();
        }
    }
}
