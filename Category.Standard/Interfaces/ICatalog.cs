using Category.Standard.Configs;
using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Interfaces
{
    public interface ICatalog
    {
        IReadOnlyList<Film> FilmInfos { get; }
        IReadOnlyList<DistributorCat> DistributorCats { get; }
        IReadOnlyList<string> EmptyDirs { get; }
        Extension Extensions { get; }
        ClassificationDefine ClassificationDefine { get; }
        IList<Film> FindFilms(string keyword);

        string FindDistributor(string keyword);

        void AddClassificationDefine(EClassificationDefine classificationDefine, string item);
        void DeleteClassificationDefine(EClassificationDefine classificationDefine, string item);

        void SaveExtention();

        void Init();
    }
}
