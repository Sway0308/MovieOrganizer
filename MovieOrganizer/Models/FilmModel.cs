using System.Collections.Generic;
using System.IO;

namespace MovieOrganizer.Models
{
    public class FilmModel
    {
        public FilmModel(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileNameWithoutExtension(filePath);
            ExtensionName = Path.GetExtension(filePath);
        }

        public string FilePath { get; }
        public string FileName { get; }
        public string ExtensionName { get; }
        public string Distributor { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public IList<string> Actors { get; } = new List<string>();
        public IList<string> Categories { get; } = new List<string>();
    }
}
