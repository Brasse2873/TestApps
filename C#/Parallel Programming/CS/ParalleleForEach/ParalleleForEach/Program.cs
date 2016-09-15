using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParalleleForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            int []arr = new int[10] {1,2,3,4,5,6,7,8,9,10};

            //ForEach using lambda expression
            Parallel.ForEach(arr, ix => Debug.Print("DoWork Lambda: {0}",ix) );

            //ForEach calling method
            Parallel.ForEach(arr, ix => DoWork(ix) );
        }

        static void DoWork(int par1)
        {
            Debug.Print("DoWork Method: {0}",par1);
        }
    }
}
