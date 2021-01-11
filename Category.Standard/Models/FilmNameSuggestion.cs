using System.Collections.Generic;

namespace Category.Standard.Models
{
    public class FilmNameSuggestion
    {
        public Film FilmInfo { get; set; }
        public IList<string> SuggestNames { get; set; }
    }
}
