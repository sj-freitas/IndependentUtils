using IndependentUtils.Testing.Attributes;
using IndependentUtils.Tools.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IndependentUtils.Tools.UnitTests.Extensions
{
    [TestClass]
    public class TypeExtensionsTests
    {
        [TestMethod]
        [UnitTest]
        public void TestGetFullNameWithNestedGenericTypes()
        {
            // Arrange
            var type = typeof(IDictionary<string, IEnumerable<int>>);

            // Act
            var value = type.GetFullName();

            // Assert
            Assert.AreEqual(
                "System.Collections.Generic.IDictionary<System.String,System.Collections.Generic.IEnumerable<System.Int32>>", 
                value);
        }
    }
}
