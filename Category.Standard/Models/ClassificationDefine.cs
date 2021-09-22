using Category.Standard.Configs;
using System.Collections.Generic;

namespace Category.Standard.Models
{
    internal class Classification
    { 
        public EClassificationDefine ClassificationDefine { get; set; }
        public List<string> Items { get; } = new List<string>();

        public void AddItem(string item)
        { 
            var a = item.Split(' ');
            foreach (var phrase in a)
            {
                if (Items.IndexOf(phrase) >= 0)
                    continue;

                Items.Add(phrase);
            }
        }

        public void DeleteItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                return;

            if (Items.IndexOf(item) < 0)
                return;
            Items.Remove(item);
        }
    }

    /// <summary>
    /// 片源分類
    /// </summary>
    public class ClassificationDefine
    {
        private readonly Classification ClassDistributors = new Classification { ClassificationDefine = EClassificationDefine.Distributors };
        private readonly Classification ClassActors = new Classification { ClassificationDefine = EClassificationDefine.Actors };
        private readonly Classification ClassGenres = new Classification { ClassificationDefine = EClassificationDefine.Genres };

        /// <summary>
        /// 發行商
        /// </summary>
        public IReadOnlyList<string> Distributors => ClassDistributors.Items;
        /// <summary>
        /// 演員
        /// </summary>
        public IReadOnlyList<string> Actors => ClassActors.Items;
        /// <summary>
        /// 題材
        /// </summary>
        public IReadOnlyList<string> Genres => ClassGenres.Items;

        public void AddItem(EClassificationDefine classificationDefine, string item)
        {
            switch (classificationDefine)
            {
                case EClassificationDefine.Distributors:
                    ClassDistributors.AddItem(item);
                    break;
                case EClassificationDefine.Actors:
                    ClassActors.AddItem(item);
                    break;
                case EClassificationDefine.Genres:
                    ClassGenres.AddItem(item);
                    break;
            }
        }

        public void DeleteItem(EClassificationDefine classificationDefine, string item)
        {
            switch (classificationDefine)
            {
                case EClassificationDefine.Distributors:
                    ClassDistributors.DeleteItem(item);
                    break;
                case EClassificationDefine.Actors:
                    ClassActors.DeleteItem(item);
                    break;
                case EClassificationDefine.Genres:
                    ClassGenres.DeleteItem(item);
                    break;
            }
        }
    }
}
