using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IndependentUtils.Testing.Attributes
{
    public abstract class SingleNameTestCategoryBaseAttribute : TestCategoryBaseAttribute
    {
        private readonly string[] _categories;

        protected SingleNameTestCategoryBaseAttribute(string category)
        {
            _categories = new[] { category };
        }

        public override IList<string> TestCategories
        {
            get { return _categories; }
        }
    }
}
