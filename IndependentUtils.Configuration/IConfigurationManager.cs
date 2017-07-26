using System.Collections.Specialized;
using System.Configuration;

namespace IndependentUtils.Configuration
{
    public interface IConfigurationManager
    {
        /// <summary>
        /// Retrieves a specified configuration section for the current application's default
        /// configuration.
        /// </summary>
        /// <param name="sectionName">
        /// The configuration section path and name
        /// </param>
        /// <returns>
        /// The specified System.Configuration.ConfigurationSection object, or null if 
        /// the section does not exist.
        /// </returns>
        ConfigurationSection GetSection(string sectionName);

        /// <summary>
        /// Gets the AppSettingsSection data for the current application's default configuration.
        /// </summary>
        NameValueCollection AppSettings { get; }
    }
}
