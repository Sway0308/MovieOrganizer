using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class ClassificationHandler
    {
        public void ClassifyAndExportDefines(IList<DistributorCat> distributorCats)
        {
            var currentClassification = BaseConstants.LoadInfo<ClassificationDefine>(BaseConstants.ClassificationDefinePath);

            var distributors = distributorCats.Select(x => x.Distributor.Replace("(", string.Empty).Replace(")", string.Empty)).Distinct();
            var exceptDistributors = distributors.Except(currentClassification.Distributors);
            if (exceptDistributors.Any())
                exceptDistributors.ForEach(x => currentClassification.Distributors.Add(x));

            BusinessFunc.ExportItem(currentClassification, BaseConstants.ClassificationDefinePath, false);
        }
    }
}
