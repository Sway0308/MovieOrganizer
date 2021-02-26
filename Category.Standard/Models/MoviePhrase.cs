using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Models
{
    public class MoviePhrase
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public List<string> Phrase { get; } = new List<string>();
    }
}
