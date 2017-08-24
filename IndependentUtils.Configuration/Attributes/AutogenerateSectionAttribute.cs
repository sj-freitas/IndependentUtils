using System;

namespace IndependentUtils.Configuration.Attributes
{
    public sealed class AutogenerateSectionAttribute : SectionNameAttribute
    {
        public AutogenerateSectionAttribute(string sectionName)
            : base(sectionName)
        {
        }
    }
}
