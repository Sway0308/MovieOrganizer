using Category.Standard.Handlers;
using FilmIndex.Job;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace FilmIndex.Host
{
    public class FilmIndexHost
    {
        public void Start()
        {
            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            var paths = new List<string>();
            var searchPaths = ConfigurationManager.GetSection("indexInfo/searchPath") as NameValueCollection;
            for (int i = 0; i < searchPaths.Count; i++)
            {
                paths.Add(searchPaths[i]);
            }

            var indexJob = new IndexJob { ExportPath = exportPath, FilmHandler = new FilmHandler(), FilmPaths = paths };
            indexJob.Execute();
        }
    }
}
