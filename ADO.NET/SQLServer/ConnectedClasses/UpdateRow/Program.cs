using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;

namespace UpdateRow
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMgr db = new DbMgr();
            db.UpdateRow();
        }
    }

    class DbMgr
    {
        SqlConnection conn = null;

        public DbMgr()
        {
            conn = new SqlConnection( ConfigurationManager.ConnectionStrings["LocalNorthwind"].ConnectionString );
            conn.Open();
        }


        public void UpdateRow()
        {
            SqlCommand cmd = new SqlCommand("update products set ProductName = 'Chaik' where ProductId=1", conn);
            int numUpdatedRows = cmd.ExecuteNonQuery();
        }

    }
}
