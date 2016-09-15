using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemObject
{
    class Program
    {
        static void Main(string[] args)
        {
            method1();
        }

        private static void method1()
        {
            Class1 obj1 = new Class1();
            Class2 obj2 = new Class2();

            //Equals()
            //-------
            Console.WriteLine("obj1 equal to obj1:{0}", obj1.Equals(obj1));
            Console.WriteLine("obj1 equal to obj2:{0}", obj1.Equals(obj2));

            //GetHashCode()
            //-------------
            Console.WriteLine("HashCode obj1: {0}", obj1.GetHashCode());
            Console.WriteLine("HashCode obj2: {0}", obj2.GetHashCode());

            //GetType()
            //---------
            Console.WriteLine("Type obj1: {0}", obj1.GetType());
            Console.WriteLine("Type obj1: {0}", obj2.GetType());

            //ToString()
            //----------
            Console.WriteLine("ToString obj1: {0}", obj1.ToString());
            Console.WriteLine("ToString obj2: {0}", obj2.ToString());
        }
    }


    class Class1
    {
        public int IntVar { get; set; }
    }
    class Class2
    {
        public int IntVar { get; set; }
    }
}
