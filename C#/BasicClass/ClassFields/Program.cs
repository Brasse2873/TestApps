using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassFields
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 cls1 = new Class1();
            cls1.PublicVar = 1;
            int var = cls1.PublicVar;
        }
    }

    class Class1
    {
        public int PublicVar; //member field
    }
}
