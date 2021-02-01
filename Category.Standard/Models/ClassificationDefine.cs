using System.Collections.Generic;

namespace Category.Standard.Models
{
    /// <summary>
    /// 片源分類
    /// </summary>
    public class ClassificationDefine
    {
        /// <summary>
        /// 發行商
        /// </summary>
        public IList<string> Distributors { get; } = new List<string>();
        /// <summary>
        /// 演員
        /// </summary>
        public IList<string> Actors { get; } = new List<string>();
        /// <summary>
        /// 題材
        /// </summary>
        public IList<string> Genres { get; } = new List<string>();
    }
}
