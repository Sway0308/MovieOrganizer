using Category.Standard.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Handlers
{
    public class JsonFileHandler<T> where T : class, new()
    {
        private readonly string _FilePath;

        public JsonFileHandler(string filePath)
        {
            _FilePath = filePath;
            Item = BaseConstants.LoadInfo<T>(_FilePath);
        }

        public T Item { get; private set; }

        public void SaveItemToJson(bool isIncludeSource = false)
        {
            BusinessFunc.ExportItemToFile(Item, _FilePath);
        }
    }
}
