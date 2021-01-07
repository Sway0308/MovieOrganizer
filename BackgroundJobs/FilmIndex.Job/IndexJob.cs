using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Gatchan.Base.Standard.Base;
using Category.Standard.Adaptors;

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
            for (int i = 0; i < FilmPaths.Count; i++)
            {
                var path = FilmPaths[i];
                var isRecongnized = SamplePaths.Any(x => x.SameText(path));
                var exportAndIncludeSource = i != 0;

                var filmHandler = new FilmHandler(exportAndIncludeSource, isRecongnized);
                filmHandler.RecusiveSearch(path);
                filmHandler.ExportJson();
            }

            var categoryAdaptor = new CatalogAdaptor(AppDataPath);
            var bracketHandler = new BracketHandler();
            bracketHandler.ClassifyAndExportBrackets(categoryAdaptor.FilmInfos, categoryAdaptor.DistributorCats);

            var classificationHandler = new ClassificationHandler();
            classificationHandler.ClassifyAndExportDefines(categoryAdaptor.DistributorCats);
        }
    }
}
