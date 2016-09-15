using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateServer
{
    public delegate int DelegateRetIntParInt(int par1); //Definition


    public class Class1
    {
        public void Method1( DelegateRetIntParInt func, int par2 )
        {
            func( par2 );
        }
    }

}

namespace DelegatesClient
{
    using DelegateServer;

    class Program
    {
        static void Main(string[] args)
        {
            //Normal declaration and instansiation
            //------------------------------------
            DelegateRetIntParInt delegateVar;                   //Declaration of the delegate
            delegateVar = new DelegateRetIntParInt(Method1);    //Instansiation of a delegate class


            Class1 obj = new Class1();
            delegateVar(0);                                     //Invoke delegate
            obj.Method1(delegateVar, 1);                        //Delegate as parameter


            //"Delegate Interface" way to declare and instansiate
            //---------------------------------------------------
            Class2 obj2 = new Class2();
            DelegateRetIntParInt delegateVar2 = obj2.Method2;
            obj.Method1(delegateVar2, 2);


            //Generic delegate Func<>
            //-----------------------
            Func<int, int> delegateVar3 = obj2.Method2;         //Declare and instansiate delegate using "Delegate Interface"
            int res3 = delegateVar3(4);


            //Generic delegate Action<>
            //-------------------------
            Action<int> delegateVar4 = Class2.Method3;          //Delegate method is static method
            delegateVar4(5);


            //Multicast delegate
            //------------------
            Action<int> multicastDelegateVar = Method3;         //Create and Add first method
            multicastDelegateVar += Class2.Method3;             //Add second method
            multicastDelegateVar(11);                           //Invoke all methods


            //Anonymous method
            //----------------
            Func<int, int> delegateVar5 = delegate(int par1)
            {
                Console.WriteLine("Anonymous method: par={0}", par1);
                return 0;
            };
            delegateVar5(12);
        }

        static public int Method1( int par1 )
        {
            Console.WriteLine("Program.Method1: par={0}", par1);
            return 0;
        }
        static public void Method3(int par1)
        {
            Console.WriteLine("Program.Method3: par={0}", par1);
        }
    }




    class Class2
    {
        public int Method2(int par1)
        {
            Console.WriteLine("Class2.Method2: par={0}", par1);
            return 0;
        }

        public static void Method3(int par1)
        {
            Console.WriteLine("Class2.Method3: par={0}", par1);
        }
    }

  
}

