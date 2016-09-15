using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Using Service T:\Utveckling Testprogram\WCF\Services\BasicService
//Start the service before debug this code

using Proxy_ServiceReference.BasicServiceReference;

namespace Proxy_ServiceReference
{
    class Program
    {
        static void Main(string[] args)
        {
        Proxy_ServiceReference.BasicServiceReference.BasicServiceClient proxy = new BasicServiceClient();

        Console.WriteLine("Call to BasicService.Method(1). Returned: {0}", proxy.Method( 1 ) );
        Console.ReadLine();
        }
    }
}
