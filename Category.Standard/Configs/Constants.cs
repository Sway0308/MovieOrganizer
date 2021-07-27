using Gatchan.Base.Standard.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        public static string DistributorCatPath => Path.Combine(AppDataPath, "distributor_category.json");
        public static string EmptyDirPath => Path.Combine(AppDataPath, "empty_dir.json");
        public static string ClassificationDefinePath => Path.Combine(AppDataPath, "classification_define.json");
        public static string BracketPath => Path.Combine(AppDataPath, "bracket.json");
        public static string MoviePhrasePath => Path.Combine(AppDataPath, "movie_phrase.json");
        public static string PhrasePath => Path.Combine(AppDataPath, "phrases.json");

        public static void SetExportPath(string appDataPath)
        {
            AppDataPath = appDataPath;
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CategoryType
    {
        Undefined,
        Distributor,
        Identification
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PhraseType
    { 
        Undefined,
        Actress,
        Subject
    }
}
