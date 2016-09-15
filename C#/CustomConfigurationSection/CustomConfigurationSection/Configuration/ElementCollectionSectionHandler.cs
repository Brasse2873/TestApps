using System;
using System.Configuration;

namespace CustomConfigurationSection.Configuration
{

    public class ElementCollectionSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("oneElementCollection")]
        public OneElementCollection elements
        {
            get { return (OneElementCollection)base["oneElementCollection"]; }
        }
    }




    [ConfigurationCollection(typeof(OneElement))]
    public class OneElementCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "oneElement";

        #region ConfigurationElementCollection implementation

        /// <summary>
        /// Another important thing that you need to address in this implementation is CreateNewElement. You need to return the actual implementation of your ConfigurationElement here.
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new OneElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((OneElement)element).Attribute1;
        }

        /// <summary>
        /// The ElementName represents the name of the Tag that you use in Config file.
        /// </summary>
        protected override string ElementName { get { return PropertyName; } }

        protected override bool IsElementName(string elementName){ return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase); }

        public override ConfigurationElementCollectionType CollectionType { get { return ConfigurationElementCollectionType.BasicMapAlternate; } }

        public override bool IsReadOnly()
        {
 	            return false;
        }
        #endregion

        /// <summary>
        /// Here the first thing that you notice is we define an Indexer for the class and return BaseGet(index). The BaseGet actually reads the configuration collection and use Reflection to create object of the ConfigurationElement
        /// </summary>
        /// <param name="ix"></param>
        /// <returns></returns>
        public OneElement this[int ix] { get{ return (OneElement)BaseGet(ix); } }
    }
}
