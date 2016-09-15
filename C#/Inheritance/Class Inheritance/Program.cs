using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassAA obj1 = new ClassAA();

            System.Console.WriteLine("Field1={0}, Field2={1}", obj1.Field1, obj1.Field2);
            obj1.Field1 = 1;
            obj1.Field2 = 2;
            System.Console.WriteLine("Field1={0}, Field2={1}", obj1.Field1, obj1.Field2);
        }
    }


    public class ClassA
    {
        public int Field1{ get; set; } 
    }

    public class ClassAA : ClassA
    {
        public int Field2 { get; set; }
    }
}
