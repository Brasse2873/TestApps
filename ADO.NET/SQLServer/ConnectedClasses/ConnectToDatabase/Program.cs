using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


//Add referense to System.Configuration (to read config file)
//Use https://www.connectionstrings.com for help to build connection strings

namespace ConnectToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ConnectUsing_SqlClient();
                ConnectUsing_Odbc();

            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message );
            }
        
        }

        //Only for SQL Server
        static void ConnectUsing_SqlClient()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SqlClient"].ConnectionString);
            sb.ApplicationName = "ConnectToDatabase_SqlClient";

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(sb.ConnectionString))
            {
                conn.Open();               
                Console.WriteLine("SqlClient:" + sb.ConnectionString);
            }
        }


        static void ConnectUsing_OleDb()
        {

        }


        static void ConnectUsing_Odbc()
        {
            ConnectUsing_Odbc_SqlServer();
            ConnectUsing_Odbc_Excel();
        }

        //Downloaded and installed: Microsoft® ODBC Driver 13.1 for SQL Server® - Windows, Linux, & macOS
        static void ConnectUsing_Odbc_SqlServer()
        {
            System.Data.Odbc.OdbcConnectionStringBuilder sb = new System.Data.Odbc.OdbcConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Odbc_SqlServer"].ConnectionString);
            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("ODBC_SqlServer:" + sb.ConnectionString);
            }
        }

        //Downloaded and installed: Microsoft Access Database Engine 2010 Redistributable
        static void ConnectUsing_Odbc_Excel()
        {
            System.Data.Odbc.OdbcConnectionStringBuilder sb = new System.Data.Odbc.OdbcConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Odbc_Excel"].ConnectionString);

            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("ODBC_Excel:" + sb.ConnectionString);
            }

        }
    }
}
