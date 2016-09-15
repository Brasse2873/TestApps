using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Namespace.part1;

namespace Namespace
{
    public class Class1
    {
        public Class1()
        {
            part1Class obj1 = new part1Class();
            string str = obj1.getNamespace();
        }
        
        //part2Class obj2 = new part2Class(); detta går inte
    }

    namespace part2
    {
        class Class2
        {
            public Class2()
            {
                part2Class obj2 = new part2Class();
                string str = obj2.getNamespace();
            }
        }
    }
}
