using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass context = new MyClass();

            Console.WriteLine(context.StateIndependentMethod());

            Console.WriteLine(context.StateDependentMethod());

            context.StateChangingEvent();

            Console.WriteLine(context.StateDependentMethod());
        }
    }
}
