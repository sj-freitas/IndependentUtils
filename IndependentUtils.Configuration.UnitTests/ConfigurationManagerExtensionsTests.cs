using IndependentUtils.Configuration.Attributes;
using IndependentUtils.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Configuration;

namespace IndependentUtils.Configuration.UnitTests
{
    [TestClass]
    public class ConfigurationManagerExtensionsTests
    {
        private const string SectionName = "testName";
        
        private class SampleConfigSectionWithoutAttribute : ConfigurationSection
        {
        }

        [SectionName(SectionName)]
        private class SampleConfigSection : ConfigurationSection
        {
        }

        [TestMethod]
        [UnitTest]
        public void TestGetSectionFromTypeAndNameReturnsSection()
        {
            // Arrange
            var sampleSectionInstance = new SampleConfigSection();
            var mockConfigManager = new Mock<IConfigurationManager>();
            mockConfigManager
                .Setup(t => t.GetSection(SectionName))
                .Returns(sampleSectionInstance);

            // Act
            var configSection = mockConfigManager.Object;
            var section = configSection.GetSection<SampleConfigSection>(SectionName);

            // Assert
            Assert.AreEqual(sampleSectionInstance, section);
            mockConfigManager.VerifyAll();
        }

        [TestMethod]
        [UnitTest]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetSectionFromTypeWithoutNameNorAttributeThrowsException()
        {
            // Arrange
            var mockConfigManager = new Mock<IConfigurationManager>();

            // Act
            var configSection = mockConfigManager.Object;
            var section = configSection.GetSection<SampleConfigSection>();

            // Assert
            // -- Exception should happen.
        }

        [TestMethod]
        [UnitTest]
        public void TestGetSectionFromAttribute()
        {
            // Arrange
            var sampleSectionInstance = new SampleConfigSection();
            var mockConfigManager = new Mock<IConfigurationManager>();
            mockConfigManager
                .Setup(t => t.GetSection(SectionName))
                .Returns(sampleSectionInstance);

            // Act
            var configSection = mockConfigManager.Object;
            var section = configSection.GetSection<SampleConfigSection>();

            // Assert
            Assert.AreEqual(sampleSectionInstance, section);
            mockConfigManager.VerifyAll();
        }
    }
}
