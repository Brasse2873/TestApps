using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CallStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();

            db.CallStoredProcedure();
        }
    }

    class DbMgr
    {
        SqlConnection conn;

        public DbMgr()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString);
            conn.Open();
        }

        public void CallStoredProcedure()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "CustOrderHist";

            SqlParameter par = cmd.CreateParameter();
            par.ParameterName = "@CustomerID";
            par.Value = "ALFKI";
            cmd.Parameters.Add( par );

            SqlDataReader dr =  cmd.ExecuteReader();

            while( dr.Read() )
            {
                Console.WriteLine("{0},{1}",dr[0],dr[1] );
            }
        }
    }
}
