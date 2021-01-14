using System.Collections.Generic;

namespace Category.Standard.Interfaces
{
    public interface IRule
    {
        IList<IRuleModel> Find();
        void Solve();
    }
}
