using System;



namespace BasicExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();

            obj.Method1();
            obj.Method2();

            try
            {
                Class2 obj2 = new Class2();
                obj2.Method1();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main: catch");
            }
        }
    }


    public class Class1
    {
        public void Method1()
        {
            Console.WriteLine("Class1.Method1(): Before try block");

            try
            {
                Console.WriteLine("Class1.Method1():try block");

                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class1.Method1():catch block.");
                Console.WriteLine("\t ex.Message: {0}", ex.Message);
                Console.WriteLine("\t ex.Source: {0}", ex.Source );
                Console.WriteLine("\t ex.ToString: {0}", ex.ToString() );
            }
            finally
            {
                Console.WriteLine("Class1.Method1():finally block");
            }

            Console.WriteLine("Class1.Method1(): after finnaly block");
        }

        public void Method2()
        {
            try
            {
                throw new Exception("My error message");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class1.Method2():catch block.");
                Console.WriteLine("\t ex.Message: {0}", ex.Message);
                Console.WriteLine("\t ex.Source: {0}", ex.Source);
                Console.WriteLine("\t ex.ToString: {0}", ex.ToString());
            }
        }
    }


    public class Class2
    {
        public void Method1()
        {
            try
            {
                Console.WriteLine("Class1.Method1: try");
                Method2();
            }
            finally
            {
                Console.WriteLine("Class1.Method1: finally");
            }
        }

        private void Method2()
        {
            throw new Exception();
        }
    }
}
