using System.Configuration;

namespace CustomConfigurationSection.Configuration
{
    public class OneElementSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("attribute1")]
        public string Attribute1 { get { return (string)this["attribute1"]; }}

        [ConfigurationProperty("oneElement")]
        public OneElement AOneElement { get { return (OneElement)this["oneElement"]; }}
    }
}
