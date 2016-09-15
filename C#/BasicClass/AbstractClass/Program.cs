using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Class1
    {
        protected int Field1 { get; set; }

        protected abstract int AbstractMethod1(int par1);
        int Method1(int par1)
        {
            Field1 += par1;
            return Field1;
        }
    }

    public class Class2 : Class1
    {
        protected override int AbstractMethod1(int par1)
        {
            Field1 -= par1;
            return Field1;
        }        
    }


}
