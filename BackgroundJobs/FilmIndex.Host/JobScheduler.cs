using FilmIndex.Job;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FilmIndex.Host
{
    public class JobScheduler : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("FilmIndexHost Starting...");
            var appDataPath = ConfigurationManager.AppSettings["ExportPath"];
            Console.WriteLine($"AppDataPath: {appDataPath}");
            var filmPaths = new List<string>();
            var searchPaths = ConfigurationManager.GetSection("indexInfo/searchPath") as NameValueCollection;
            for (int i = 0; i < searchPaths.Count; i++)
            {
                filmPaths.Add(searchPaths[i]);
                Console.WriteLine($"SearchPath: {searchPaths[i]}");
            }

            var paths = new List<string>();
            var samplePaths = ConfigurationManager.GetSection("indexInfo/samplePath") as NameValueCollection;
            for (int i = 0; i < samplePaths.Count; i++)
            {
                paths.Add(samplePaths[i]);
                Console.WriteLine($"SamplePath: {samplePaths[i]}");
            }

            var indexJob = new IndexJob { AppDataPath = appDataPath, FilmPaths = filmPaths, SamplePaths = paths };
            Console.WriteLine($"Start Indexing...");
            var sw = new Stopwatch();
            sw.Start();
            indexJob.Execute();
            sw.Stop();
            Console.WriteLine($"End Indexing...");
            Console.WriteLine($"elapse time: {sw.ElapsedMilliseconds}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
