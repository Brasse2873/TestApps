using System;

namespace NestedMethodException
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            obj1.Method1();


            Class2 obj2 = new Class2();
            obj2.Method1();
        }
    }

    public class Class1
    {
        public void Method1()
        {
            try
            {
                Console.WriteLine("Method1: try");
                Method2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method1: catch");
                Console.WriteLine("\t Description: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Method1: finally");
            }
        }

        private void Method2()
        {
            try
            {
                Console.WriteLine("Method2: try");
                Method3();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method2: catch");
                Console.WriteLine("\t Description: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Method2: finally");
            }
        }

        private void Method3()
        {
            try
            {
                Console.WriteLine("Method3: try");
                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method3: catch");
                Console.WriteLine("\t Description: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Method3: finally");
            }
        }
    }



    public class Class2
    {
        public void Method1()
        {
            try
            {
                Console.WriteLine("Method1: try");
                Method2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method1: catch");
                Console.WriteLine("\t Description: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Method1: finally");
            }
        }

        private void Method2()
        {
            try
            {
                Console.WriteLine("Method2: try");
                Method3();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method2: catch");
                Console.WriteLine("\t Description: {0}", ex.ToString());
                throw ex;
            }
            finally
            {
                Console.WriteLine("Method2: finally");
            }
        }

        private void Method3()
        {
            try
            {
                Console.WriteLine("Method3: try");
                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method3: catch");
                Console.WriteLine("\t Description: {0}", ex.ToString());
                throw ex;
            }
            finally
            {
                Console.WriteLine("Method3: finally");
            }
        }
    }
}
