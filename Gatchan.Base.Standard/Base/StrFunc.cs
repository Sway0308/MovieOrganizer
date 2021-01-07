using System;
using System.Linq;

namespace Gatchan.Base.Standard.Base
{
    public static class StrFunc
    {
        public static bool SameText(this string s, string value)
        {
            return s.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool SameTextOr(this string s, params string[] values)
        {
            return values.Any(x => x.SameText(s));
        }

        public static bool IncludeText(this string s, string value)
        {
            return s.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}
