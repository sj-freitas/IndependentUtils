using IndependentUtils.Testing.Attributes;
using IndependentUtils.Tools.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentUtils.Tools.UnitTests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        [UnitTest]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSplittingALongWordThrowsException()
        {
            // Arrange
            const string text = "thiswordislongerthan20characters";

            // Act
            text.SplitByLineSize(20).ToList();
        }

        [TestMethod]
        [UnitTest]
        public void TestSplittingASingleLineTheSameSizeAsMaximumReturnsTheSameLine()
        {
            // Arrange
            const string text = "this setence will have the same size as the line size";

            // Act
            var result = text.SplitByLineSize(text.Length).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(text, result[0]);
        }

        [TestMethod]
        [UnitTest]
        public void TestSplittingAText()
        {
            // Arrange
            var lines = new[]
            {
                "This is a sentence with a few ",
                "characters, but it's important ",
                "to notice that this line is ",
                "actually over the limit. So, ",
                "it'll be cut to the next line."
            };
            var text = string.Join(string.Empty, lines);

            // Act
            var result = text.SplitByLineSize(31).ToArray();

            // Assert
            for (var i = 0; i < lines.Length; i++)
            {
                Assert.AreEqual(lines[i].Trim(), result[i].Trim());
            }
        }
    }
}
