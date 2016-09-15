using System.Configuration;

namespace CustomConfigurationSection.Configuration
{
    public class OneElement : ConfigurationElement
    {
        [ConfigurationProperty("attribute1")]
        public string Attribute1 { get { return (string)this["attribute1"]; } }

        public override string ToString()
        {
            return "Attribute1=" + Attribute1;
        }
    }
}
