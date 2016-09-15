using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Namespace
{
    class Program1
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            //Class2 class2 = new Class2();             går inte
            //part1Class classp1 = new part1Class();    går inte
            part2.Class2 class2 = new part2.Class2();
            part1.part1Class classp1 = new part1.part1Class();
            string str = classp1.getNamespace();            
        }
    }

    namespace part1
    {
        class part1Class
        {
            public string getNamespace() 
            {
                return "part1";
            }
        }
    }

    namespace part2
    {
        class part2Class
        {
            public string getNamespace()
            {
                return "part2";
            }
        }
    }
}
