using System.Collections.Generic;
using System.Configuration;

namespace IndependentUtils.Configuration
{
    public class ConfigurationElementCollection<TElement> : ConfigurationElementCollection, IEnumerable<TElement>
        where TElement : ConfigurationElement, IKeyd, new()
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TElement)element).Key;
        }

        public TElement this[int position]
        {
            get
            {
                return (TElement)BaseGet(position);
            }
        }

        public new IEnumerator<TElement> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }
    }
}
