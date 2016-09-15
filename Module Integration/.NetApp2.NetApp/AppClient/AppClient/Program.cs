using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppServer;

namespace AppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassInAppServer o = new ClassInAppServer();
            o.IntPar = 100;
            Console.WriteLine("ClassInAppServer.IntPar="+ o.IntPar);
        }
    }
}
