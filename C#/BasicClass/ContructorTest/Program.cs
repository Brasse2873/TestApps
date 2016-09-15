using System;

namespace ContructorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            Console.WriteLine("obj1 Field = " + obj1.Field);

            Class1 obj2 = new Class1("MyVal");
            Console.WriteLine("obj2 Field = " + obj2.Field);
        }
    }

    public class Class1
    {
        public string Field { get; set; }
        public Class1()
            : this("Test")
        {
        }

        public Class1(string val)
        {
            Field = val;
        }
    }
}
