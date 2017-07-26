using System;

namespace IndependentUtils.Configuration.Attributes
{
    public class AutogenerateSectionAttribute : Attribute
    {
        private readonly string _sectionName;

        public string SectionName
        {
            get
            {
                return _sectionName;
            }
        }

        public AutogenerateSectionAttribute(string sectionName)
        {
            _sectionName = sectionName;
        }
    }
}
