using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            obj1.Method1();
        }
    }


    public interface IInterface1
    {
        void Method1();
    }


    public class Class1 : IInterface1
    { 
        public void Method1()
        {
            System.Console.WriteLine("Method1");
        }
    }

}
