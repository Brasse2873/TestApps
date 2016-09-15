using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            obj.method1<int>(1);
            obj.method1(1);

            obj.method1<string>("Main");
            obj.method1("Main");

            obj.method1<Class1>(obj);
            obj.method1(obj);


            obj.method2<int,int>(1,2);
            obj.method2<int, string>(1, "Main");
            obj.method2<int, Class1>(1, obj);

            int res = obj.method3<int>(1);
            double res2 = obj.method3<double>(1.0);

        
        }
    }

    class Class1
    {
        public void method1<T>(T par1)
        {
            Console.WriteLine("par1 = {0}", par1);
        }

        public void method2<T1,T2>(T1 par1,T2 par2)
        {
            Console.WriteLine("par1 = {0}, par2 = {1}", par1, par2 );
        }

        public T method3<T>(T par1)
            where T : struct
        {
            T ret = par1;
            return ret;
        }
    }
}
