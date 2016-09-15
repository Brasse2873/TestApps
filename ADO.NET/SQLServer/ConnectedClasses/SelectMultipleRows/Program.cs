using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SelectMultipleRows
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();
            db.SelectMultipleRows();
               
        }
    }


    class DbMgr
    {
        SqlConnection conn = null;

        public DbMgr()
        {
            conn = new SqlConnection( ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString);
            conn.Open();
        }

        public void SelectMultipleRows()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from products";


            SqlDataReader dr = cmd.ExecuteReader();

            while( dr.Read() )
            {
                Console.WriteLine("ProductID:{0}, ProductName:{1}",dr["ProductID"], dr["ProductName"]);
            }

        }
    }
}
