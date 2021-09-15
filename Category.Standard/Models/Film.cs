using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.IO;

namespace Category.Standard.Models
{
    /// <summary>
    /// 影片設定
    /// </summary>
    public class Film
    {
        public Film()
        { 
        }

        public Film(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        private bool IsFilePathEmpty => string.IsNullOrEmpty(FilePath);
        public string DirectoryName => IsFilePathEmpty ? string.Empty : Directory.GetParent(FilePath).Name;
        public string DirectoryPath => IsFilePathEmpty ? string.Empty : Directory.GetParent(FilePath).FullName;
        public string FileName => IsFilePathEmpty ? string.Empty : Path.GetFileNameWithoutExtension(FilePath);
        public string Extension => IsFilePathEmpty ? string.Empty : Path.GetExtension(FilePath);
        public string Distributor { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public IList<Bracket> Brackets { get; } = new List<Bracket>();
        public IList<string> Genres { get; } = new List<string>();
        public IList<string> Actors { get; } = new List<string>();

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

        public override int GetHashCode()
        {
            return FilePath.GetHashCode();
        }
    }
}
