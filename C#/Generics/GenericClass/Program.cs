using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1<int> obj1 = new Class1<int>();
            obj1.FieldT = 1;
            int var1 = obj1.FieldT;

            Class1<string> obj2 = new Class1<string>();
            obj2.FieldT = "obj2";
            string var2 = obj2.FieldT;

            Class1<Class1<int>> obj3 = new Class1<Class1<int>>();
            obj3.FieldT = new Class1<int>();
            Class1<int> var3 = obj3.FieldT;




            Class2<int, string> obj4 = new Class2<int, string>();
            obj4.Field1 = 1;
            obj4.Field2 = "obj4";

        }
    }

    class Class1<T>
    {
        private T fieldT = default(T);
        public T FieldT
        {
            get { return fieldT; }
            set { fieldT = value; }
        }
    }

    class Class2<TPar1, TPar2>
    {
        private TPar1 field1 = default(TPar1);
        public TPar1 Field1
        {
            get { return field1; }
            set { field1 = value; }
        }

        private TPar2 field2 = default(TPar2);
        public TPar2 Field2
        {
            get { return field2; }
            set { field2 = value; }
        }
    }
}
