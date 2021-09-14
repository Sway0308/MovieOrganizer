using Category.Standard.Interfaces;
using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Helpers
{
    public static class FilmHelper
    {
        public static (string Title, string Category, string Identity, int DashIndex) ExtractSearchText(string searchText)
        {
            var dashIndex = searchText.IndexOf("-");
            if (dashIndex < 0)
                return (string.Empty, searchText, string.Empty, -1);
            if (!searchText.StartsWith("("))
            {
                var category = searchText.Substring(0, dashIndex);
                var identity = searchText.Substring(0, searchText.IndexOf(" "));
                var title = searchText.Substring(searchText.IndexOf(" ") + 1, searchText.Length - identity.Length - 1);
                return (title, category, identity, dashIndex);
            }
            else
            {
                var firstIndexOfRightBracket = searchText.IndexOf(")");
                var identity = searchText.Substring(1, firstIndexOfRightBracket - 1);
                var category = identity.Substring(0, dashIndex - 1);
                var title = searchText.Substring(firstIndexOfRightBracket + 1, searchText.Length - (identity.Length + 2));
                return (title, category, identity, dashIndex);
            }
        }

        public static (string distributor, string suggestName) GetSuggestFilmName(ICatalog catalog, string oriName)
        {
            var result = ExtractSearchText(oriName);
            var distributor = catalog.FindDistributor(result.Category);

            if (string.IsNullOrEmpty(distributor))
                return (distributor, oriName);
            
            if (result.DashIndex < 0)
                return (distributor, $"({distributor})");
            else
                return  (distributor, $"({distributor})({result.Identity}){result.Title}");
        }
    }
}
