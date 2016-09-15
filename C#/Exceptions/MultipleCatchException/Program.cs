using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleCatchException
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            obj1.Method1(new Exception());
            obj1.Method1(new SystemException());
            obj1.Method1(new ApplicationException());
            obj1.Method1(new ArgumentException());
        }
    }


    public class Class1
    {
        public void Method1( Exception ex )
        {
            if (ex == null)
                return;

            try
            {
                Console.WriteLine("Class1.Method1: throw exception {0}", ex.ToString());
                throw ex;
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Class1.Method1: catch (ArgumentException)");
            }
            catch (SystemException)
            {
                Console.WriteLine("Class1.Method1: catch (SystemException)");
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Class1.Method1: catch (ApplicationException)");
            }
            catch (Exception)
            {
                Console.WriteLine("Class1.Method1: catch (Exception)");
            }
            finally
            {
                Console.WriteLine("Class1.Method1: finally");
            }
        }

    }
}
