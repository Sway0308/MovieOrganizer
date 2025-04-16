using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Handlers
{
    public class FilmFileHandler : JsonListFileHandler<Film>
    {
        public FilmFileHandler(string filePath) : base(filePath)
        {
        }
    }

    public class HistoryFilmFileHandler : JsonListFileHandler<FilmItem>
    {
        public HistoryFilmFileHandler(string filePath) : base(filePath)
        {
        }
    }

    public class DistributorCatFileHandler : JsonListFileHandler<DistributorCat>
    {
        public DistributorCatFileHandler(string filePath) : base(filePath)
        {
        }
    }
    public class EmptyDirFileHandler : JsonListFileHandler<string>
    {
        public EmptyDirFileHandler(string filePath) : base(filePath)
        {
        }
    }
    public class ExtensionFileHandler : JsonFileHandler<Extension>
    {
        public ExtensionFileHandler(string filePath) : base(filePath)
        {
        }
    }
    public class ClassificationDefineFileHandler : JsonFileHandler<ClassificationDefine>
    {
        public ClassificationDefineFileHandler(string filePath) : base(filePath)
        {
        }
    }
}
