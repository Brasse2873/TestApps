using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EARTHLib;

namespace InteractWithCOMComponent
{
    class Program
    {
        static void Main(string[] args)
        {
            EARTHLib.KHViewInfoClass ge = new KHViewInfoClass();
            string info = ge.ToString();
        }
    }
}
