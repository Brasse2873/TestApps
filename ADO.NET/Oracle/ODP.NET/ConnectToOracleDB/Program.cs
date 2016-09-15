using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types; 

/*
 * Step 1: Add Oracle.DataAccess to References
 *      2: Add a using statement for Oracle.DataAccess.Client
 *      3: Add a connection string
 */

namespace ConnectToOracleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectUsingSimpleConnectionString();

            ConnectUsingConnectionStringBuilder();

        }

        static private void ConnectUsingSimpleConnectionString()
        {
            //uses tnsname "eagle"
            string oracleDb = "Data Source=eagle;User Id=falungong;Password=test;";

            try
            { 
                OracleConnection conn = new OracleConnection(oracleDb); 
                conn.Open();
                conn.Dispose();
            }
            catch( OracleException e )
            { 
                Console.WriteLine( e.Message );
            }
        }

        static private void ConnectUsingConnectionStringBuilder()
        {
            OracleConnectionStringBuilder connSB = new OracleConnectionStringBuilder();
            connSB.UserID = "falungong";
            connSB.Password = "test";
            connSB.DataSource = "eagle";

            try
            {
                OracleConnection conn = new OracleConnection( connSB.ConnectionString );
                conn.Open();
                conn.Close();
            }
            catch ( Exception e)
            { 
                Console.WriteLine( e.Message );
            }
        }

    }
}
