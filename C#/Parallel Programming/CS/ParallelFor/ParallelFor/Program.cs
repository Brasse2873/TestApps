using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

public delegate void DeligateDoWork(int par1);

namespace ParallelFor
{

    class Program
    {
        static void Main(string[] args)
        {

            //Parallel.For using Lamda expression. Preferable method
            Parallel.For(0
                        ,10
                        ,par1 => Debug.Print("Lambda expression DoWork: {0}", par1)
                        );

            //Parallel.For using method.
            Parallel.For(10
                        , 20
                        , par1 => DoWork(par1)
                        );

            //Break a loop. Stops the loop. All started steps will continou to run until end. No new steps
            Parallel.For(20
                        , 50
                        , (par1,loopState) => 
                            {
                                Debug.Print("Break the loop when par1 = 25: {0}", par1);

                                if( par1 ==25 )
                                { 
                                    loopState.Break();
                                    return;
                                }

                                Thread.Sleep(2000);
                            }
                        );

            return;
        }

        static void DoWork(int par1)
        {
            Debug.Print("Method DoWork: {0}",par1);
        }

   }

}
