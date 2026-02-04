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
            try
            {
                Execute();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "FilmIndexHost Error");
            }
#if DEBUG
            Console.ReadKey();
#endif
        }

        private void Execute()
        {
            Logger.LogInformation("FilmIndexHost Starting...");
            var appDataPath = ConfigurationManager.AppSettings["ExportPath"];
            Logger.LogInformation($"AppDataPath: {appDataPath}");

            var exportSettings = GetExportPaths(appDataPath);

            foreach (var item in exportSettings.SearchPath)
            {
                Logger.LogInformation($"SearchPath: {item}");
            }

            foreach (var item in exportSettings.SamplePath)
            {
                Logger.LogInformation($"SamplePath: {item}");
            }

            foreach (var item in exportSettings.HistoryExcludeRules)
            {
                Logger.LogInformation($"HistoryExcludeRules: {item}");
            }

            var indexJob = new IndexJob { AppDataPath = appDataPath, ExportSettings = exportSettings };
            Logger.LogInformation($"Start Indexing...");
            var sw = new Stopwatch();
            sw.Start();
            indexJob.Execute();
            sw.Stop();
            Logger.LogInformation($"End Indexing...");
            Logger.LogInformation($"elapse milliseconds: {sw.ElapsedMilliseconds}");
            Logger.LogInformation("----------------------------------------------------------------");
        }

        private ExportSettings GetExportPaths(string exportPath)
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

            return exportSettings;
        }

        private ExportSettings GetDefaultExportPaths(string exportPath)
        {
            var filmPaths = new List<string>();
            var searchPaths = ConfigurationManager.GetSection("indexInfo/searchPath") as NameValueCollection;
            for (int i = 0; i < searchPaths.Count; i++)
            {
                filmPaths.Add(searchPaths[i]);
            }

            var paths = new List<string>();
            var samplePaths = ConfigurationManager.GetSection("indexInfo/samplePath") as NameValueCollection;
            for (int i = 0; i < samplePaths.Count; i++)
            {
                paths.Add(samplePaths[i]);
            }

            var excludeRules = new List<string>();
            var excludeRulePaths = ConfigurationManager.GetSection("indexInfo/excludeRulePaths") as NameValueCollection;
            for (int i = 0; i < excludeRulePaths.Count; i++)
            {
                excludeRules.Add(excludeRulePaths[i]);
            }

            return new ExportSettings { SearchPath = filmPaths, SamplePath = paths, HistoryExcludeRules = excludeRules };
            
        }
    }
}
