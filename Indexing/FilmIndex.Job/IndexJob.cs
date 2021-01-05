using Category.Standard.Configs;
using Category.Standard.Handlers;
using Category.Standard.Interfaces;
using System.Collections.Generic;

namespace FilmIndex.Job
{
    public class IndexJob : IJobExecuter
    {
        public string ExportPath { get; set; }
        public IList<string> FilmPaths { get; set; }
        public FilmHandler FilmHandler { get; set; }

        public void Execute()
        {
            BaseConstants.SetExportPath(ExportPath);
            foreach (var path in FilmPaths)
            {
                FilmHandler.RecusiveSearch(path);
                FilmHandler.ExportJson();
            }
        }
    }
}
