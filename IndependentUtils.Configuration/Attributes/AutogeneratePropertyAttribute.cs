using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace IndependentUtils.Configuration.Attributes
{
    public class AutogeneratePropertyAttribute : Attribute
    {
        /// <summary>
        /// Qualifies that the property is an option.
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        private class OptionAttribute : Attribute
        {
        }

        private readonly string _name;

        public string Name => _name;

        public string AddItemName { get; set; }

        [Option]
        public object DefaultValue { get; set; }

        [Option]
        public ConfigurationPropertyOptions Options { get; set; }

        [Option]
        public bool IsDefaultCollection { get; set; }

        [Option]
        public bool IsRequired { get; set; }

        public IEnumerable<KeyValuePair<string, object>> AdditionalSettings => 
            typeof(AutogeneratePropertyAttribute).GetProperties()
                .Where(t => t.GetCustomAttribute<OptionAttribute>() != null)
                .Select(t => new KeyValuePair<string, object>(t.Name, t.GetValue(this)))
                .Where(t => !IsDefaultValue(t.Value));

        public AutogeneratePropertyAttribute(string name) => _name = name;

        private static bool IsDefaultValue(object obj)
        {
            if (obj == null)
            {
                return true;
            }

            return obj.Equals(GetDefaultValueOf(obj.GetType()));
        }

        private static object GetDefaultValueOf(Type elementType)
        {
            if (elementType.IsValueType)
            {
                return Activator.CreateInstance(elementType);
            }
            return null;
        }
    }
}
