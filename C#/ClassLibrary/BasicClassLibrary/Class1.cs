using System;


namespace BasicClassLibrary
{
    public class Class1
    {
        private void PrivateMethod()
        {
            Console.WriteLine("BasicClassLibrary.Class1.PrivateMethod");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("BasicClassLibrary.Class1.ProtectedMethod");
        }

        public void PublicMethod()
        {
            Console.WriteLine("BasicClassLibrary.Class1.PublicMethod");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("BasicClassLibrary.Class1.InternalMethod");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("BasicClassLibrary.Class1.StaticMethod");
        }
    }
}
