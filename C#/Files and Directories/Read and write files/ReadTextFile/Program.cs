using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleOpen();
            MoreAdvancedOpen();
        }

        static void SimpleOpen()
        {
            using (FileStream stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + @"..\..\test.txt"))
            {
                StreamReader sr = new StreamReader(stream);
                String line = sr.ReadLine();
            }
        }

        static void MoreAdvancedOpen()
        {
            using (FileStream stream = new FileStream(
                AppDomain.CurrentDomain.BaseDirectory + @"..\..\test.txt"
                , FileMode.Open
                , FileAccess.Read
                , FileShare.Read))
            {
                StreamReader sr = new StreamReader(stream);
                String line = sr.ReadLine();
            }
        }

    }
}
