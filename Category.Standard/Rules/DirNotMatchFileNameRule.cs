using Category.Standard.Abstracts;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Category.Standard.Rules
{
    [Description("Dir Not Match FileName")]
    public class DirNotMatchFileNameRule : AbstractRule, IRule
    {
        public DirNotMatchFileNameRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films)
            {
                if (film.FileName.SameText(film.DirectoryName))
                    continue;
                if (result.Any(x => x.Main.SameText(film.DirectoryPath))) continue;

                var newDir = film.DirectoryPath.Replace(film.DirectoryName, string.Empty) + film.FileName;
                result.Add(new FilmDirectorySuggestion { Film = film, Answers = new List<string> { newDir } });
            }

            return result;
        }
    }
}
