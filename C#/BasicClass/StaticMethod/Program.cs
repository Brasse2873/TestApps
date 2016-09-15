using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1.method1();

            Class1 obj1 = new Class1();
            //obj1.method1();       //Not allowed
            obj1.method2();

        }
    }

    class Class1
    {
        public int IntVar { get; set; }

        //Static method
        public static void method1()
        {
            Console.WriteLine("Class1");
            //Console.WriteLine("{0}", this.ToString());    //Not allowed
        }

        //Non static method
        public void method2()
        {
            Console.WriteLine("{0}", this.ToString());
        }
    }
}
