using System.Collections.Generic;

namespace FilmIndex.Host
{
    public class ExportSettings
    {
        public IList<string> SearchPath { get; set; }
        public IList<string> SamplePath { get; set; }
        public IList<string> HistoryExcludeRules { get; set; }
    }
}