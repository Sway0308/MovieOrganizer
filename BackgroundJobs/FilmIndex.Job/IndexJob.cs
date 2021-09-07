using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Gatchan.Base.Standard.Base;
using Category.Standard.Adaptors;
using Category.Standard.Models;

namespace FilmIndex.Job
{
    public class IndexJob : IJobExecuter
    {
        public string AppDataPath { get; set; }
        public IList<string> FilmPaths { get; set; }
        public IList<string> SamplePaths { get; set; }

        public void Execute()
        {
            BaseConstants.SetExportPath(AppDataPath);

            ReDefine();
            for (int i = 0; i < FilmPaths.Count; i++)
            {
                var path = FilmPaths[i];
                var isRecongnized = SamplePaths.Any(x => x.SameText(path));
                var exportAndIncludeSource = i != 0;

                var filmHandler = new FilmInDirHandler(exportAndIncludeSource, isRecongnized);
                filmHandler.RecusiveSearch(path);
                filmHandler.ExportJson();
            }

            var categoryAdaptor = new CatalogAdaptor(AppDataPath);

            var classificationHandler = new ClassifyDistributorHandler();
            classificationHandler.ClassifyAndExportDefines(categoryAdaptor.DistributorCats);

            var currentClassification = BaseConstants.LoadInfo<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
            var phraseHandler = new PhraseHandler();
            phraseHandler.ClassifyAndExportDefines(categoryAdaptor.FilmInfos, currentClassification);
        }
        
        private void ReDefine()
        {
            var src = new List<DistributorCat>();
            BaseConstants.LoadInfos(BaseConstants.DistributorCatPath, src);

            var dest = new List<DistributorCat>();
            foreach (var item in src)
            {
                if (!dest.Any(x => x.Equals(item)))
                    dest.Add(item);
            }

            if (!src.Any(x => dest.Any(y => x.Equals(y))))
            {
                BusinessFunc.ExportListToFile(dest, BaseConstants.DistributorCatPath, false);
            }
        }
    }
}
