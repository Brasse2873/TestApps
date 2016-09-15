using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;

namespace SelectScalarValue
{
    class Program
    {
        static void Main(string[] args)
        {
            DBMgr db = new DBMgr();

            db.Connect();

            db.SelectScalarValue();

            db.Disconnect();            
        }
    }


    class DBMgr
    {   
        SqlConnection conn = null;

        public void Connect()
        {
            if( conn == null )
            {
                conn = new SqlConnection( ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString );
                conn.Open();
            }
        }

        public void Disconnect()
        {
            if( conn != null )
            {
                conn.Close();
            }
        }

        public void SelectScalarValue()
        {
            SqlCommand cmd = new SqlCommand("Select count(*) from Products",conn);
            int count = (int)cmd.ExecuteScalar();
        }

    }
}
