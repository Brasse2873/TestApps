using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1.IntVar = 1;
            int res1 = Class1.IntVar;
            Class1.func1();

            //Kolla att det värdet som sattes i main är samma värde som Class2 ser
            Class2 obj2 = new Class2();
            obj2.func1();

        }
    }

    //Det går inte att skapa en instans av denna class
    //Class properties ligger på heapen globalt
    static class Class1
    {
        public static int IntVar { get; set; }
        public static void func1()
        {
            Console.WriteLine("Class1: IntVar={0}",Class1.IntVar);
        }
    }


    class Class2
    {
        public void func1()
        {
            Class1.func1();
        }
    }
}
