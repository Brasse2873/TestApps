using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Client.BasicServiceReference;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            BasicServiceClient proxy = new BasicServiceClient();
            
            Console.WriteLine("Service(1) returned {0}", proxy.Method1(1) );
        }
    }
}
