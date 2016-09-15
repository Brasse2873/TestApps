using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ReadAndUpdateRows
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();
            db.SelectAndUpdateRows();
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
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString );
            Conn.Open();
        } 

        public void SelectAndUpdateRows()
        {
            SqlCommand cmd = Conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Region";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
        }
    }
}
