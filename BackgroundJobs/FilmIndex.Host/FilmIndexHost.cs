using FilmIndex.Job;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;

namespace FilmIndex.Host
{
    public class FilmIndexHost
    {
        private readonly ILogger<FilmIndexHost> Logger = BussinessFunc.GetLogger<FilmIndexHost>();

        public void Start()
        {
            Logger.LogInformation("FilmIndexHost Starting...");
            var appDataPath = ConfigurationManager.AppSettings["ExportPath"];
            Logger.LogInformation($"AppDataPath: {appDataPath}");
            var filmPaths = new List<string>();
            var searchPaths = ConfigurationManager.GetSection("indexInfo/searchPath") as NameValueCollection;
            for (int i = 0; i < searchPaths.Count; i++)
            {
                filmPaths.Add(searchPaths[i]);
                Logger.LogInformation($"SearchPath: {searchPaths[i]}");
            }

            var paths = new List<string>();
            var samplePaths = ConfigurationManager.GetSection("indexInfo/samplePath") as NameValueCollection;
            for (int i = 0; i < samplePaths.Count; i++)
            {
                paths.Add(samplePaths[i]);
                Logger.LogInformation($"SamplePath: {samplePaths[i]}");
            }

            var indexJob = new IndexJob { AppDataPath = appDataPath, FilmPaths = filmPaths, SamplePaths = paths };
            Logger.LogInformation($"Start Indexing...");
            var sw = new Stopwatch();
            sw.Start();
            indexJob.Execute();
            sw.Stop();
            Logger.LogInformation($"End Indexing...");
            Logger.LogInformation($"elapse time: {sw.ElapsedMilliseconds}");
            Logger.LogInformation("----------------------------------------------------------------");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
