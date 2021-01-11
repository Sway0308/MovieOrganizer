using Category.Standard.Models;
using System.Collections.Generic;

namespace Category.Standard.Interfaces
{
    public interface IRule
    {
        IList<FilmNameSuggestion> Find();
        void Solve();
    }
}
