using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UpdateDBFromDisconnectedData
{
    class Program
    {
        static void Main(string[] args)
        {

            try {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConTest1"].ToString());
                sb.ApplicationName = "UpdateDBFromDisconnectedData";
                using (SqlConnection con = new SqlConnection(sb.ToString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {

                    }
                }
            }
            catch (Exception e){ 
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
