using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();

            int x;
            obj.IntVar = 1;
            x = obj.IntVar;

            //obj.IntVar2 = 2;  ej tillåtet
            x = obj.IntVar2;

            obj.StrVar1 = "Main";
            string res = obj.StrVar2;
        }
    }

    class Class1
    {
        public Class1()
        {
            StrVar1 = "Class1.StrVar1";
            StrVar2 = "Class1.StrVar2";
        }

        //public get and set
        int intVar;
        public int IntVar
        {
            get { return intVar; }
            set { intVar = value; }
        }

        //public get, private set
        int intVar2;
        public int IntVar2
        {
            get { return intVar2; }
            private set { intVar2 = value; }
        }

        //Auto-implemented property
        public string StrVar1 { get; set; }
        public string StrVar2 { get; private set; }
    }
}
