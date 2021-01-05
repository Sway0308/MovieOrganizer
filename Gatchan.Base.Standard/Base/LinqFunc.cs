using System;
using System.Collections.Generic;

namespace Gatchan.Base.Standard.Base
{
    public static class LinqFunc
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action.Invoke(item);
            }
        }
    }
}
