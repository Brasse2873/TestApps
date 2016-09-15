using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DeleteRow
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();
            db.DeleteRow();
        }
    }

    class DbMgr
    {
        SqlConnection _conn;
        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public DbMgr()
        {
            _conn = new SqlConnection( ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString );
            Conn.Open();
        }

        public void DeleteRow()
        {
            SqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Delete from Region where RegionID = 46";
            cmd.CommandType = CommandType.Text;
            int countRowsDeleted = cmd.ExecuteNonQuery();
        }
    }
}
