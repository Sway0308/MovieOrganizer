using Category.Standard.Configs;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Handlers
{
    public class ClassifyDistributorHandler
    {
        public void ClassifyAndExportDefines(IList<DistributorCat> distributorCats)
        {
            var currentClassification = BaseConstants.LoadInfo<ClassificationDefine>(BaseConstants.ClassificationDefinePath);
            foreach (var item in distributorCats)
            {
                if (!currentClassification.Distributors.Any(x => x.IncludeText(item.Distributor)))
                    currentClassification.AddItem(EClassificationDefine.Distributors, item.Distributor);
            }

            BusinessFunc.ExportItemToFile(currentClassification, BaseConstants.ClassificationDefinePath);
        }
    }
}
