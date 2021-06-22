using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class BracketHandler
    {
        public BracketHandler()
        {
        }

        public void ClassifyAndExportBrackets(IList<Film> filmInfos, IList<DistributorCat> distributorCats)
        {
            foreach (var film in filmInfos.Where(x => x.Brackets.Count > 0))
            {
                film.Brackets.ForEach(x => DefineBracketType(x, distributorCats));
            }
            ExportJson(filmInfos);
        }

        private void DefineBracketType(Bracket bracket, IList<DistributorCat> distributorCats)
        {
            if (distributorCats.Any(x => x.Distributor.SameText(bracket.Text)))
            {
                bracket.Type = CategoryType.Distributor;
                return;
            }

            if (distributorCats.Any(x => bracket.Text.StartsWith(x.Category)))
            {
                bracket.Type = CategoryType.Identification;
            }
        }

        private void ExportJson(IList<Film> filmInfos)
        {
            var list = filmInfos.SelectMany(x => x.Brackets).OrderBy(x => x.Type).ThenByDescending(x => x.Text);

            var result = new Dictionary<string, Bracket>();
            foreach (var item in list)
            {
                if (!result.ContainsKey(item.Text))
                    result.Add(item.Text, item);
            }

            BusinessFunc.ExportListToFile(result.Values, BaseConstants.BracketPath, false);
        }
    }
}
