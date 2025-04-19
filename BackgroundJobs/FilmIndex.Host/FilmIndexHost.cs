using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using FilmIndex.Job;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

            var (filmPaths, samplePaths) = GetExportPaths(appDataPath);

            var indexJob = new IndexJob { AppDataPath = appDataPath, FilmPaths = filmPaths, SamplePaths = samplePaths };
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

        private (IList<string> filmPaths, IList<string> samplePaths) GetExportPaths(string exportPath)
        {
            if (!Directory.Exists(exportPath))
                return GetDefaultExportPaths(exportPath);
 
            var file = Path.Combine(exportPath, "export_settings.json");
            if (!File.Exists(file))
                return GetDefaultExportPaths(exportPath);

            ExportSettings exportSettings;
            try
            {
                var json = File.ReadAllText(file);
                exportSettings = JsonConvert.DeserializeObject<ExportSettings>(json);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Failed to read export settings");
                return GetDefaultExportPaths(exportPath);
            }

            foreach (var item in exportSettings.SearchPath)
            {
                Logger.LogInformation($"SearchPath: {item}");
            }

            foreach (var item in exportSettings.SamplePath)
            {
                Logger.LogInformation($"SamplePath: {item}");
            }

            return (exportSettings.SearchPath, exportSettings.SamplePath);
        }

        private (IList<string> filmPaths, IList<string> samplePaths) GetDefaultExportPaths(string exportPath)
        {
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

            return (filmPaths, paths);
            
        }
    }
}
