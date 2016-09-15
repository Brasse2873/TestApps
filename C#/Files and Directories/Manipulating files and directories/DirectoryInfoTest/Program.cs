using System;
using System.IO;

namespace DirectoryInfoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDirectory.TestDirectoryClass();

            TestDirectory.TestDirectoryInfoClass();
        }

    }

    public class TestDirectory
    {
        public static void TestDirectoryClass()
        {
            Directory.CreateDirectory("c:\\temp\\DirectoryInfoTest");
            Console.WriteLine("Directorty c:\\temp\\DirectoryInfoTest created");

            Console.WriteLine("Subdirectories in c:\\");
            foreach (var dir in Directory.EnumerateDirectories("c:\\"))
            {
                Console.WriteLine("\t" + dir);
            }

            Console.WriteLine("Files in c:\\");
            foreach (var file in Directory.EnumerateFiles("c:\\"))
            {
                Console.WriteLine("\t" + file);
            }

            Console.WriteLine("Files and directories in c:\\");
            foreach (var item in Directory.EnumerateFileSystemEntries("c:\\"))
            {
                Console.WriteLine("\t" + item );
            }
        }

        public static void TestDirectoryInfoClass()
        {
            DirectoryInfo di = new DirectoryInfo("c:\\");
        }
    }
}
