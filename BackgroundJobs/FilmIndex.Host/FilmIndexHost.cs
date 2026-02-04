using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration; // Can remove? Maybe used for fallback? No, replacing.
using System.Diagnostics;
using System.IO;
using FilmIndex.Job;
using Microsoft.Extensions.Configuration; // Added
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
            
            var config = BussinessFunc.GetConfiguration();
            var appDataPath = config["ExportPath"];
            
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
            var config = BussinessFunc.GetConfiguration();

            var filmPaths = new List<string>();
            foreach (var section in config.GetSection("indexInfo:searchPath").GetChildren())
            {
                filmPaths.Add(section.Value);
            }

            var paths = new List<string>();
            foreach (var section in config.GetSection("indexInfo:samplePath").GetChildren())
            {
                paths.Add(section.Value);
            }

            var excludeRules = new List<string>();
            foreach (var section in config.GetSection("indexInfo:excludeRulePaths").GetChildren())
            {
                excludeRules.Add(section.Value);
            }

            return new ExportSettings { SearchPath = filmPaths, SamplePath = paths, HistoryExcludeRules = excludeRules };
        }
    }
}
