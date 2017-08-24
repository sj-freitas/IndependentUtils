using System.Collections.Generic;

namespace IndependentUtils.Tools
{
    public static class ListUtils
    {
        /// <summary>
        /// Returns a collection that will be empty in case that the current value is null.
        /// </summary>
        public static List<T> GetValueOrEmpty<T>(ref List<T> collection)
        {
            if (collection == null)
            {
                collection = new List<T>();
                return collection;
            }
            return collection;
        }
    }
}
