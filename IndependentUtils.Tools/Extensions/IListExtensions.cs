using System;
using System.Collections.Generic;

namespace IndependentUtils.Tools.Extensions
{
    public static class IListExtensions
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> elementsToAdd)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (elementsToAdd == null)
            {
                throw new ArgumentNullException(nameof(elementsToAdd));
            }

            foreach (var curr in elementsToAdd)
            {
                list.Add(curr);
            }
        }
    }
}
