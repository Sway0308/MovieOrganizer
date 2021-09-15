using Category.Standard.Abstracts;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Category.Standard.Rules
{
    [Description("Repeated Identifications")]
    public class RepeatedIdentificationsRule : AbstractRule, IRule
    {
        public RepeatedIdentificationsRule(ICatalog catalog) : base(catalog)
        {
        }

        public IList<IRuleModel> Find()
        {
            var result = new List<IRuleModel>();
            foreach (var film in Films)
            {
                if (string.IsNullOrEmpty(film.Identification))
                    continue;
                if (result.Any(x => x.Main.SameText(film.Identification)))
                    continue;
            
                var repeats = FindRepeatFilms(film);
                    //Films.Where(x => x != film && !string.IsNullOrEmpty(x.Identification) && film.Identification.SameText(x.Identification));
                if (repeats.Count <= 1)
                    continue;
            
                var answers = new List<Film>();
                foreach (var item in repeats)
                {
                    if (repeats.Any(x => x != item && x.DirectoryPath.SameText(item.DirectoryPath)))
                        continue;            
                    answers.Add(item);
                }
            
                if (answers.Count <= 1)
                    continue;
            
                result.Add(new RepeatedIdentifications { Identification = film.Identification, FilmInfos = answers });
            }

            FindRepeatedFilms(result);

            return result;
        }

        private IList<Film> FindRepeatFilms(Film film)
        {
            var result = new List<Film>();
            foreach (var item in Films)
            {
                if (item == film)
                    continue;

                if (!string.IsNullOrEmpty(item.Identification) && film.Identification.SameText(item.Identification))
                    result.Add(item);
            }
            return result;
        }

        public void FindRepeatedFilms(List<IRuleModel> result)
        {
            var definedIdenFilms = Films.Where(x => !string.IsNullOrEmpty(x.Identification));
            var notDefinedIdenFilms = Films.Where(x => string.IsNullOrEmpty(x.Identification));
            foreach (var film in definedIdenFilms)
            {
                if (result.Any(x => x.Main.SameText(film.Identification)))
                    continue;

                var iden = film.Identification.Replace("(", string.Empty).Replace(")", string.Empty);
                var ans = notDefinedIdenFilms.Where(x => x.FileName.IndexOf(iden, 0, StringComparison.InvariantCultureIgnoreCase) >=0 || x.DirectoryName.IndexOf(iden, 0, StringComparison.InvariantCultureIgnoreCase) >= 0);
                if (!ans.Any())
                    continue;
                
                var answers = new List<Film> { film };
                foreach (var item in ans)
                {
                    if (answers.Any(x => x != item && x.DirectoryPath.SameText(item.DirectoryPath)))
                        continue;

                    answers.Add(item);
                }
                result.Add(new RepeatedIdentifications { Identification = film.Identification, FilmInfos = answers });
            }
        }
    }
}
