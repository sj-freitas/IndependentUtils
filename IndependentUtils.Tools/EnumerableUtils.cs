using System.Collections.Generic;
using System.Linq;

namespace IndependentUtils.Tools
{
    public static class EnumerableUtils
    {
        /// <summary>
        /// Returns a collection that will be empty in case that the current value is null.
        /// </summary>
        public static IEnumerable<T> GetValueOrEmpty<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return Enumerable.Empty<T>();
            }
            return collection;
        }
    }
}
