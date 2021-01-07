using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class BracketHandler
    {
        private readonly IList<Film> FilmInfos;
        private readonly IList<DistributorCat> DistributorCats;

        public BracketHandler(IList<Film> filmInfos, IList<DistributorCat> distributorCats)
        {
            FilmInfos = filmInfos;
            DistributorCats = distributorCats;
        }

        public void ClassifyBrackets()
        {
            foreach (var film in FilmInfos.Where(x => x.Brackets.Count > 0))
            {
                film.Brackets.ForEach(x => DefineBracketType(x));
            }
        }

        private void DefineBracketType(Bracket bracket)
        {
            if (DistributorCats.Any(x => x.Distributor.SameText(bracket.Text)))
            {
                bracket.Type = CategoryType.Distributor;
                return;
            }

            if (DistributorCats.Any(x => bracket.Text.StartsWith(x.Category)))
            {
                bracket.Type = CategoryType.Identification;
            }
        }

        public void ExportJson()
        {
            var list = FilmInfos.SelectMany(x => x.Brackets).OrderBy(x => x.Text).ThenByDescending(x => x.Type);
            BusinessFunc.ExportList(list, BaseConstants.BracketPath, false);
        }
    }
}
