using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Proxy generated with svcutil. Proxy name BasicServiceReference.cs
//Example:svcutil http://localhost:8733/ /out:BasicServiceReference.cs /d:"T:\Utveckling Testprogram\WCF\Clients\Proxy_SvcUtilGenerated\BasicServiceReference"



namespace Proxy_SvcUtilGenerated
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicServiceClient proxy = new BasicServiceClient();

            Console.WriteLine("Call to BasicService.Method(1). Return value:{0}", proxy.Method(1) );
            Console.ReadLine();
        }
    }
}
