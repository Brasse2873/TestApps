using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            obj1.Method1();
        }
    }


    class Class1
    {
        public void Method1()
        {

            //One line lamda method
            //---------------------
            Func<int,int> lambdaVar = intPar => intPar * 2;
            Console.WriteLine( "Result of lambda method: {0}", lambdaVar( 2 ) );


            //Multiple lambda method lines
            //----------------------------
            Func<int, int> lamdaVar2 = intPar =>
                {
                    Console.WriteLine("Lambda method. inPar={0}, result={1}", intPar, ++intPar);
                    return intPar;
                };
            lamdaVar2(10);

            Func<int, string> lambda3 = intPar => intPar.ToString();
            Console.WriteLine("lambda3 return: {0}",lambda3( 10 ));
        }
    }
}
