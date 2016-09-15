using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace CreateDataTableClass
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable testTabel = new DataTable("TestTable");
            
            Console.WriteLine( "Table name:{0}", testTabel.TableName );
        }
    }
}
