using Gatchan.Base.Standard.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Category.Standard.Configs
{
    public static class BaseConstants
    {
        public static string AppDataPath { get; private set; } = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\";
        public static string ExtensionPath => Path.Combine(AppDataPath, "extension.json");
        public static string FilmPath => Path.Combine(AppDataPath, "film.json");
        public static string DistributorCatPath => Path.Combine(AppDataPath, "distributorCat.json");
        public static string BracketPath => Path.Combine(AppDataPath, "bracket.json");
        public static string EmptyDirPath => Path.Combine(AppDataPath, "emptyDir.json");

        public static void SetExportPath(string exportPath)
        {
            AppDataPath = exportPath;
        }

        public static T LoadInfo<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void LoadInfos<T>(string filePath, IList<T> infos)
        {
            infos.Clear();
            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);
            var items = JsonConvert.DeserializeObject<IList<T>>(json);
            items.ForEach(x => { infos.Add(x); });
        }
    }

    public enum CategoryType
    {
        Undefined,
        Distributor,
        Identification,
        ExtraInfo
    }
}
