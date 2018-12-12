using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMemoryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleDataTable dt = new SimpleDataTable();
            Console.Write(dt.ToString());

            Console.WriteLine("Max rate:{0}", dt.MaxRate());

            dt.AddColumnRateAsDouble();

            Console.WriteLine("Max rateDouble:{0}", dt.MaxRateDouble());

            Console.WriteLine("Max rate:{0}", dt.MaxRateUsingLinq() );

            Console.WriteLine("Min rate:{0}", dt.MinRateUsingLinq());

        }


    }
}
