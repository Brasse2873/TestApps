using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method1(); Not allowed as this is a static method
            Method2(); 
            Class1 obj0 = new Class1();
            obj0.Method0();

            Class1 obj1 = new Class1();
            int res = obj1.Method1(1, 2);
            Console.WriteLine("method1 returned {0}\n", res);

            int x = 1;
            string str = "Main";
            obj1.Method2(x,str);
            Console.WriteLine("After method2:\tx={0}, str={1}\n", x, str);

            Class1 obj2 = new Class1();
            obj1.Method3(ref x, ref str, obj2);
            Console.WriteLine("After Method3:\tx={0}, str={1}, obj={2}\n", x, str, obj2.IntVar);

            int x4;
            string str4;
            Class1 obj4;
            obj1.Method4(out x4, out str4, out obj4);
            Console.WriteLine("After Method4:\tx={0}, str={1}, obj={2}\n", x4, str4, obj4.IntVar);


            //Call with named parameters (parameter order changed)
            obj1.Method2(str: "Hej Hopp", x:10);

            //Call with optional parameters
            obj1.Method5();
            obj1.Method5(1);
            obj1.Method5(2,"Main");
            Class1 obj5 = new Class1();
            obj5.IntVar = 5;
            obj1.Method5(3, "Main",obj5);

        }

        public void Method1() { }
        static public void Method2() { }

    }

    class Class1
    {
        private int intVar;
        public int IntVar
        {
            get { return intVar; }
            set { intVar = value; }
        }

        //Normal method calling internal method
        public int Method0()
        {
            return Method1(1, 2);
        }

        //Normal method with return value
        public int Method1(int x, int y)
        {
            return x + y;
        }

        //Method with value type parameters
        public void Method2(int x, string str)
        {
            x++;
            str += "/Method2";
            Console.WriteLine("method2:\tx={0}, str={1}", x, str);
        }

        //Method with reference type parameters
        public void Method3(ref int x, ref string str, Class1 obj)
        {
            x++;
            str += "/Method3";
            obj.IntVar++;
            Console.WriteLine("Method3:\tx={0}, str={1}, obj={2}", x, str, obj.IntVar);
        }

        //Method with out parameters
        public void Method4(out int x, out string str, out Class1 obj)
        {
            x = 1;
            str = "Method4";
            obj = new Class1();
            Console.WriteLine("Method4:\tx={0}, str={1}, obj={2}", x, str, obj.IntVar);
        }

        //Method with optional parameter
        public void Method5(int x = 0, string str = "", Class1 obj = null )
        {
            Console.WriteLine("Method5:\tx={0}, str={1}, obj={2}", x, str, obj==null?0:obj.IntVar);
        }
    }
}
