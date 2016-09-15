using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            LibServer.ClassInLibServer o = new LibServer.ClassInLibServer();
            o.IntPar = 100;
            Console.WriteLine("ClassInLibServer.IntPar="+o.IntPar);
        }
    }
}
