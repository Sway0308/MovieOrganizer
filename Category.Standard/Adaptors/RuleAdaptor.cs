using Category.Standard.Interfaces;
using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Category.Standard.Adaptors
{
    public class RuleAdaptor
    {
        public RuleAdaptor(string path)
        {
            var rules = Assembly.Load("Category.Standard").GetTypes().Where(x => x is IRule);
            RuleTypes = rules;

            CatalogAdaptor = new CatalogAdaptor(path);
        }

        public CatalogAdaptor CatalogAdaptor { get; }

        public IEnumerable<Type> RuleTypes { get; }

        public string GetDescription(Type ruleType)
        {
            if (!ruleType.IsDefined(typeof(DescriptionAttribute)))
                return string.Empty;

            var desc = ruleType.GetCustomAttribute<DescriptionAttribute>();
            return desc?.Description ?? string.Empty;
        }

        public IList<FilmNameSuggestion> FindByRule(int index)
        {
            var ruleType = RuleTypes.ElementAt(index);
            var rule = (IRule)Activator.CreateInstance(ruleType, CatalogAdaptor.FilmInfos, CatalogAdaptor.DistributorCats);
            return rule.Find();
        }
    }
}
