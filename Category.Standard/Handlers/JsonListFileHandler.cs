using Category.Standard.Configs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Category.Standard.Handlers
{
    public class JsonListFileHandler<T>
    {
        private readonly string _FilePath;

        public JsonListFileHandler(string filePath)
        {
            _FilePath = filePath;
            BaseConstants.LoadInfos(_FilePath, Items);
        }

        public List<T> Items { get; } = new List<T>();

        public void SaveItemsToJson(bool isIncludeSource = false)
        {
            BusinessFunc.ExportListToFile(Items, _FilePath, isIncludeSource);
        }

        public async Task SaveItemsToJsonAsync(bool isIncludeSource = false)
        {
            await BusinessFunc.ExportListToFileAsync(Items, _FilePath, isIncludeSource);
        }
    }
}
