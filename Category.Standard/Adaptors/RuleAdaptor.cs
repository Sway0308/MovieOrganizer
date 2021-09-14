using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Category.Standard.Adaptors
{
    public class RuleAdaptor
    {
        private readonly ICatalog _Catalog;

        public RuleAdaptor(string path)
        {
            var type = typeof(IRule);
            var rules = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => type.IsAssignableFrom(x));
            RuleTypes = rules;

            _Catalog = new CatalogAdaptor(path);
        }

        public IEnumerable<Type> RuleTypes { get; }

        public string GetDescription(Type ruleType)
        {
            if (!ruleType.IsDefined(typeof(DescriptionAttribute)))
                return string.Empty;

            var desc = ruleType.GetCustomAttribute<DescriptionAttribute>();
            return desc?.Description ?? string.Empty;
        }

        public IList<IRuleModel> FindByRule(int index)
        {
            var ruleType = RuleTypes.ElementAt(index);
            if (ruleType.IsInterface)
                return new List<IRuleModel>();

            var rule = (IRule)Activator.CreateInstance(ruleType, _Catalog);
            return rule.Find();
        }
    }
}
