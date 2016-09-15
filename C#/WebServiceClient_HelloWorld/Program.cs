using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WebServiceClient_HelloWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			MyService.Service1 service = new MyService.Service1(); 

			Console.WriteLine( service.HelloWorld() );
		}
	}
}
