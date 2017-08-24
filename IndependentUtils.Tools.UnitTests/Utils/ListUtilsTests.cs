using IndependentUtils.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IndependentUtils.Tools.UnitTests.Utils
{
    [TestClass]
    public class ListUtilsTests
    {
        public class ClassWithAList
        {
            private List<string> _aList;

            public List<string> AList
            {
                get => ListUtils.GetValueOrEmpty(ref _aList);
                set => _aList = value;
            }
        }

        [TestMethod]
        [UnitTest]
        public void TestGetValueOrEmptyWorksWithCallingEmptyElement()
        {
            // Arrange
            const string value = "value";
            var element = new ClassWithAList();

            // Act
            element.AList.Add(value);

            // Assert
            Assert.AreEqual(value, element.AList.Single());
        }
    }
}
