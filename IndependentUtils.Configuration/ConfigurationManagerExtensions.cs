using IndependentUtils.Configuration.Attributes;
using System;
using System.Configuration;
using System.Reflection;

namespace IndependentUtils.Configuration
{
    public static class ConfigurationManagerExtensions
    {
        /// <summary>
        /// Gets the section of the specific type from the SectionNameAttribute name.
        /// If there is no SectionNameAttribute present, an exception is thrown.
        /// </summary>
        /// <typeparam name="TConfigSection">The configuration section type.</typeparam>
        /// <param name="configurationManager">The configuration manager instance.</param>
        /// <returns>The existing configuration section or null if not found.</returns>
        public static TConfigSection GetSection<TConfigSection>(this IConfigurationManager configurationManager)
            where TConfigSection : ConfigurationSection
        {
            if (configurationManager == null)
            {
                throw new ArgumentNullException(nameof(configurationManager));
            }

            var nameAttribute = typeof(TConfigSection).GetCustomAttribute<SectionNameAttribute>();
            if (nameAttribute == null)
            {
                throw new InvalidOperationException(
                    "Cannot get a config section from a nameless config or a configuration" +
                    $"without a [{nameof(SectionNameAttribute)}] attribute.");
            }

            return GetSection<TConfigSection>(configurationManager, nameAttribute.SectionName);
        }

        /// <summary>
        /// Gets the section of the specific type from the parameterized name.
        /// </summary>
        /// <typeparam name="TConfigSection">The configuration section type.</typeparam>
        /// <param name="configurationManager">The configuration manager instance.</param>
        /// <returns>The existing configuration section or null if not found.</returns>
        public static TConfigSection GetSection<TConfigSection>(this IConfigurationManager configurationManager,
            string sectionName)
            where TConfigSection : ConfigurationSection
        {
            if (configurationManager == null)
            {
                throw new ArgumentNullException(nameof(configurationManager));
            }
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                throw new ArgumentNullException(nameof(sectionName));
            }

            var section = configurationManager.GetSection(sectionName);
            if (section == null)
            {
                throw new InvalidOperationException($"There is no section called \"{sectionName}\"!");
            }

            return section as TConfigSection;
        }
    }
}
