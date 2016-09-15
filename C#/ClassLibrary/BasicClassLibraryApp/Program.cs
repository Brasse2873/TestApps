using System;
using BasicClassLibrary;

namespace BasicClassLibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();

            obj1.PublicMethod();

            Class1.StaticMethod();

        }
    }
}
