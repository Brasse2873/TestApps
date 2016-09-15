using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;


namespace InteractWith.NETAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Word.ApplicationClass  word = new ApplicationClass();
            string ver = word.Version;
        }
    }
}
