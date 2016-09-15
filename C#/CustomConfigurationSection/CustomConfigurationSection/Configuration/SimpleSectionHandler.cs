using System.Configuration;

namespace CustomConfigurationSection.Configuration
{
    public class SimpleSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("attribute1")]
        public string Attribute1
        {
            get { return (string)this["attribute1"];}
        }

        [ConfigurationProperty("attribute2")]
        public string Attribute2
        {
            get { return (string)this["attribute2"]; }
        }
    }
}
