using System.Collections.Specialized;
using System.Configuration;

namespace IndependentUtils.Configuration
{
    /// <summary>
    /// Wraps the default System.Configuration.ConfigurationManager static class.
    /// </summary>
    public class DefaultConfigurationManager : IConfigurationManager
    {
        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        public ConfigurationSection GetSection(string sectionName)
        {
            return (ConfigurationSection)ConfigurationManager.GetSection(sectionName);
        }
    }
}
