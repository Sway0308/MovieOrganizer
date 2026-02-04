using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task ExportListToFileAsync<T>(IEnumerable<T> items, string path, bool isIncludeSource)
        {
            var sources = new List<T>();
            if (isIncludeSource)
            {
                await BaseConstants.LoadInfosAsync(path, sources);
            }

            foreach (var item in items)
            {
                if (!sources.Any(x => x.Equals(item)))
                    sources.Add(item);
            }

            var str = JsonConvert.SerializeObject(sources, Formatting.Indented);
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                await writer.WriteAsync(str);
            }
        }

        public static void ExportItemToFile<T>(T item, string path) where T : new()
        {
            var str = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(path, str, Encoding.UTF8);
        }

        public static async Task ExportItemToFileAsync<T>(T item, string path) where T : new()
        {
            var str = JsonConvert.SerializeObject(item, Formatting.Indented);
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                await writer.WriteAsync(str);
            }
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
