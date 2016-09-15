using System;
using System.Text;
using System.Configuration;
using CustomConfigurationSection.Configuration;

namespace CustomConfigurationSection
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSimpleSectionHandler();
            TestOneElementSectionHandler();
            TestElementCollectionSectionHandler();
            Console.ReadLine();
        }

        private static void TestSimpleSectionHandler()
        {
            SimpleSectionHandler settings = ConfigurationManager.GetSection("simpleSection") as SimpleSectionHandler;
            Console.WriteLine("SimpleSection.attribute1:" + settings.Attribute1);
        }

        private static void TestOneElementSectionHandler()
        {
            OneElementSectionHandler settings = ConfigurationManager.GetSection("oneElementSection") as OneElementSectionHandler;
            Console.WriteLine("oneElementSection.attribute1:" + settings.Attribute1);
            Console.WriteLine("settings.AOneElement.Attribute1:" + settings.AOneElement.Attribute1);
        }

        private static void TestElementCollectionSectionHandler()
        {
            ElementCollectionSectionHandler settings = ConfigurationManager.GetSection("elementCollectionSection") as ElementCollectionSectionHandler;
            foreach( OneElement e in settings.elements )
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
