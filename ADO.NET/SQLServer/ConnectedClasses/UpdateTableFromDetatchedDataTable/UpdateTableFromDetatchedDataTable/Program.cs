using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Updates a table in MySql database with values from detached DataTable object.
/// 
/// Table: name=table2, col1=id autoinc, col2=name, col3=amount 
/// </summary>

namespace UpdateTableFromDetatchedDataTable
{
    class Program
    {
        static void Main(string[] args)
        {

            //1: Connect to DB
            MySqlConnection conn = new MySqlConnection("server=localhost;database=test1;uid=root;pwd=Scarlett1986");
            conn.Open();

            //2: Get Data from DB
            DataTable dtDb = GetDBTable(conn);
            Console.WriteLine("Rows in dtDB: {0}", dtDb.Rows.Count);

            //3: We need a detatched DataTable. Simulate if retrieved from CSV file (UiPath)
            DataTable dtDetached = CreateDetachedTable();

            //4: Update DataTable from DB with content of DataTable from CSV
            UpdateData(dtDetached, dtDb);
            Console.WriteLine("Rows in dtDB after update: {0}. (This include deleted rows)", dtDb.Rows.Count);
        
            //5: Push changes to DB
            UpdateTable(dtDb,conn);
        }

        private static void UpdateData(DataTable dtDetatched, DataTable dtTable)
        {
            dtTable.BeginLoadData();
            foreach (DataRow rowDetatched in dtDetatched.Rows)
            {
                DataRow row = dtTable.LoadDataRow(new object[] { null, rowDetatched["name"], rowDetatched["amount"] }, LoadOption.Upsert ); //Upsert required for correct RowState
            }
            dtTable.EndLoadData();
        }

        private static void UpdateTable(DataTable dtTable, MySqlConnection conn)
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter("select * from table2", conn)) //Sql tells CmdBuilder how to do insert,update and delete SQLs
            {
                using (MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(da)) //This is where magic happends. All changes are detected and sqls are created to perform all changes to data
                {
                    var count = da.Update(dtTable); //Push to DB
                    Console.WriteLine("Number of rows updated:" + count);
                }
            }
        }

        private static DataTable GetDBTable(MySqlConnection conn)
        {
            DataTable dt = new DataTable("FromTable");


            using (MySqlDataAdapter da = new MySqlDataAdapter(new MySqlCommand("Select * from table2",conn)))
            {
                da.Fill(dt);
                da.FillSchema(dt, SchemaType.Source); //Required to set autoincrement column
                dt.Columns["id"].AutoIncrementSeed = Convert.ToInt32(dt.AsEnumerable().Max(row => row["id"])) + 1; //Reqired to set start number for autoincrement
            }

            return dt;
        }

        static DataTable CreateDetachedTable()
        {
            DataTable dt = new DataTable("FromCsv");
            dt.Columns.AddRange( new DataColumn[2] { new DataColumn("Name"), new DataColumn("Amount", Type.GetType("System.Int32")) } );

            dt.Rows.Add( "Susanne", 1700 );
            dt.Rows.Add( "Anna", 2100 );
            dt.Rows.Add( "Johanna", 3200 );

            return dt;
        }
    }
}
