using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace InsertRow
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();
            db.InsertRow();   
        }
    }

    class DbMgr
    {
        SqlConnection conn;

        public DbMgr()
        {
            conn = new SqlConnection( ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString);
            conn.Open();
        }

        public void InsertRow()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = 
            "insert into " 
            + "  region"
            + "    (RegionId,RegionDescription)"
            + "    values(46,'Sweden')";

            int countInserted = cmd.ExecuteNonQuery();
        }


    }
}
