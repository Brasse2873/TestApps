using System;
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
                Console.WriteLine("Is 64? " + Environment.Is64BitProcess.ToString() + "\n");

                //ConnectUsing_SqlClient();
                ConnectUsing_Odbc();
            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message );
            }
        
        }

        static void ConnectUsing_SqlClient()
        {
            //ConnectUsing_SqlClient_SQLServer(); 
            ConnectUsing_MySqlClient_MySql();
        }

        static void ConnectUsing_OleDb()
        {

        }

        static void ConnectUsing_Odbc()
        {
            //ConnectUsing_Odbc_SqlServer();
            //ConnectUsing_Odbc_Excel();
            ConnectUsing_Odbc_MySql();
        }

        //SQL Server
        //No download 
        static void ConnectUsing_SqlClient_SQLServer()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SqlClient_SQLServer"].ConnectionString);
            sb.ApplicationName = "ConnectToDatabase_SqlClient";

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("SqlClient_SqlServer:\n" + sb.ConnectionString);
            }
        }

        //MySql
        //Downloaded: MySql Connector/NET 8.0.15
        static void ConnectUsing_MySqlClient_MySql()
        {
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder sb = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SqlClient_MySql"].ConnectionString);

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("SqlClient_MySql:\n" + sb.ConnectionString);
            }
        }



        // ODBC
        // =======

        //Downloaded and installed: Microsoft® ODBC Driver 13.1 for SQL Server® - Windows, Linux, & macOS
        static void ConnectUsing_Odbc_SqlServer()
        {
            System.Data.Odbc.OdbcConnectionStringBuilder sb = new System.Data.Odbc.OdbcConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Odbc_SqlServer"].ConnectionString);
            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("ODBC_SqlServer:\n" + sb.ConnectionString);
            }
        }

        //Downloaded and installed: Microsoft Access Database Engine 2010 Redistributable
        static void ConnectUsing_Odbc_Excel()
        {
            System.Data.Odbc.OdbcConnectionStringBuilder sb = new System.Data.Odbc.OdbcConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Odbc_Excel"].ConnectionString);

            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("ODBC_Excel:\n" + sb.ConnectionString);
            }

        }

        //Installed : Use MYSql installer to install Connector/ODBC. 
        //Inportant to use 32bit for 32bit app, and 64bit for 64bit apps
        static void ConnectUsing_Odbc_MySql()
        {
            System.Data.Odbc.OdbcConnectionStringBuilder sb = new System.Data.Odbc.OdbcConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Odbc_MySql"].ConnectionString);

            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(sb.ConnectionString))
            {
                conn.Open();
                Console.WriteLine("ODBC_MySql:\n" + sb.ConnectionString);
            }

        }
    }
}
