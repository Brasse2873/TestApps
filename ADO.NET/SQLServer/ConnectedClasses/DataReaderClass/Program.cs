using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataReaderClass
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();

            db.TestDataReader();
        }
    }

    class DbMgr
    {
        SqlConnection conn;

        public DbMgr()
        { 
            conn = new SqlConnection();

            conn.ConnectionString= ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString;
            conn.Open();
        }

        public void TestDataReader()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from products";
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("FieldCount:{0}", dr.FieldCount );
            Console.WriteLine("HasRows:{0}", dr.HasRows==true?"True":"False");

            //Read to get one row
            dr.Read();
            for( int ix = 0;  ix < dr.FieldCount; ++ix )
            {
                Console.WriteLine("Name:{0} ,Value:{1}, FieldType(class):{2}, DataType(db):{3}"
                    ,dr.GetName(ix).ToString()
                    ,dr.GetValue(ix).ToString()
                    ,dr.GetFieldType(ix).ToString()
                    ,dr.GetDataTypeName(ix).ToString() );
            }
        }
    }
}
