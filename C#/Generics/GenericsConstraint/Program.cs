using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsConstraint
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1<int> obj1 = new Class1<int>();
            Class1<System.DateTime> obj2 = new Class1<System.DateTime>();
            //Class1<Class2<int>> obj3 = new Class1<Class2<int>>();     //not allowed as Class2 doesn't inherit from IComparable
            Class1<Class3> obj4 = new Class1<Class3>();

            //Class2<int> obj5 = new Class2<int>();                     //not allowed as it isn't a reference type
            Class2<Class3> obj6 = new Class2<Class3>();

            Class4<int> obj7 = new Class4<int>();
            //Class2<Class3> obj8 = new Class2<Class3>();               //not allowed as it isn't a value type

            Class5<int> obj9 = new Class5<int>();
            //Class5<Class3> obj10 = new Class5<Class3>();               //not allowed as it hasn't a parameter less constructor
        }
    }

    //Derivation constraint
    class Class1<T> where T: IComparable
    {
        T field1;
        public T Field1
        {
            get { return field1; }
            set { field1 = value; }
        }
    }

    //Referens type constraint
    class Class2<T> where T : class
    {
        T field1;
        public T Field1
        {
            get { return field1; }
            set { field1 = value; }
        }
    }

    //Value type constraint
    class Class4<T> where T : struct
    {
        T field1;
        public T Field1
        {
            get { return field1; }
            set { field1 = value; }
        }
    }

    //Constructor constraint
    class Class5<T> where T : new()
    {
        T field1;
        public T Field1
        {
            get { return field1; }
            set { field1 = value; }
        }
    }














    class Class3 : IComparable
    {
        int field1;
        public int Field1
        {
            get { return field1; }
            set { field1 = value; }
        }

        Class3(int field) { field1 = field; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

}
