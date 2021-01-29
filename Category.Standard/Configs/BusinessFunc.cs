using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Category.Standard.Configs
{
    public static class BusinessFunc
    {
        public static void ExportListToFile<T>(IEnumerable<T> items, string path, bool isIncludeSource)
        {
            var sources = new List<T>();
            if (isIncludeSource)
            {
                BaseConstants.LoadInfos(path, sources);
            }

            foreach (var item in items)
            {
                if (!sources.Any(x => x.Equals(item)))
                    sources.Add(item);
            }

            var str = JsonConvert.SerializeObject(sources, Formatting.Indented);
            File.WriteAllText(path, str, Encoding.UTF8);
        }

        public static void ExportItemToFile<T>(T item, string path) where T : new()
        {
            var str = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(path, str, Encoding.UTF8);
        }

        public static string RemoveCharToEmptyStr(this string s, params string[] vs)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            foreach (var item in vs)
            {
                if (!string.IsNullOrEmpty(item))
                    s = s.Replace(item, string.Empty);
            }
            return s;
        }
    }
}
