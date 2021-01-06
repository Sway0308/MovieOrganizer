using Gatchan.Base.Standard.Base;
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
        }

        public string FilePath { get; }
        public string FileName { get; private set; }
        public string Distributor { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public IList<string> Actors { get; } = new List<string>();
        public IList<string> Genres { get; } = new List<string>();
        public IList<Bracket> Brackets { get; } = new List<Bracket>();

        public void AddBrackets(IEnumerable<Bracket> brackets)
        {
            foreach (var item in brackets)
            {
                Brackets.Add(item);
            }
        }

        public override string ToString()
        {
            return FileName;
        }

        public override bool Equals(object obj)
        {
            return this.FilePath.SameText((obj as Film)?.FilePath);
        }
    }
}
