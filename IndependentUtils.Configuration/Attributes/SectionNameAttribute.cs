using System;

namespace IndependentUtils.Configuration.Attributes
{
    /// <summary>
    /// Defines a config section name for the specific configuration section, so
    /// that it can be obtained in a more implicit fashion, without having to
    /// specify its name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SectionNameAttribute : Attribute
    {
        private readonly string _sectionName;

        public string SectionName
        {
            get
            {
                return _sectionName;
            }
        }

        public SectionNameAttribute(string sectionName)
        {
            _sectionName = sectionName;
        }
    }
}
