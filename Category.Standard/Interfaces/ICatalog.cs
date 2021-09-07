using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Interfaces
{
    public interface ICatalog
    {
        IList<Film> FilmInfos { get; }
        IList<DistributorCat> DistributorCats { get; }
        IList<string> EmptyDirs { get; }
        Extension Extensions { get; }
        ClassificationDefine ClassificationDefine { get; }
        IList<Film> FindFilms(string keyword);

        string FindDistributor(string keyword);

        void SaveExtention();

        void SaveClassificationDefine(); 
        void Init();
    }
}
