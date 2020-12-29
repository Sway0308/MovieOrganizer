using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Category.Standard.Models
{
    public class Film
    {
        public Film(string filePath)
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
        [JsonIgnore]
        public IList<Bracket> Brackets { get; } = new List<Bracket>();

        public void AddBrackets(IEnumerable<Bracket> brackets)
        {
            foreach (var item in brackets)
            {
                Brackets.Add(item);
            }
        }

        public string ToCsvFormat()
        {
            return FilePath + "," + FileName + "," + ExtensionName
                 + "," + Distributor + "," + Identification
                 + "," + string.Join("|", Actors)
                 + "," + string.Join("|", Categories);
        }
    }
}
