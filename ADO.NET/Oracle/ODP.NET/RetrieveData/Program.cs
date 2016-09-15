using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace RetrieveData
{
    class Program
    {
        static private OracleConnection conn = null;
        static private OracleCommand cmd = null;
        
        static void Main(string[] args)
        {
            ConnectDB();

            ScalarSelectCommand();

            MultipleRawsSelect();

            DisconnectDB();
        }

        static void ScalarSelectCommand()
        {
            cmd = new OracleCommand();
            cmd.CommandText = "select count(*) from v$version";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            int count = (int)cmd.ExecuteScalar();
        }

        static void MultipleRawsSelect()
        {
            cmd = new OracleCommand();
            cmd.CommandText = "select * from v$version";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while( dr.Read() )
            {   dr.

            }
        }


        static private void ConnectDB()
        {
            if (conn == null)
                conn = new OracleConnection("Data Source=eagle;User Id=falungong;Password=test");

            if (conn.State == System.Data.ConnectionState.Closed )
                conn.Open();
        }

        static private void DisconnectDB()
        {
            if (conn != null)
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}
