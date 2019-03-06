using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace AddRowToDataTable
{
    class MyDataTable : DataTable
    {
        public MyDataTable()
        {
            CreateTable();
        }

        private void CreateTable()
        {
            TableName = "TestTable";
            AddColumns();
        }

        private void AddColumns()
        {
            Columns.Add(new DataColumn("ID", typeof(Int64)));
            Columns.Add(new DataColumn("Name"));

            //Create unique id for primary key
            DataColumn col = Columns["ID"];
            col.Unique = true;
            col.AllowDBNull = false;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = -1;
            col.AutoIncrementStep = -1;
            PrimaryKey = new DataColumn[] { col };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDataTable table = new MyDataTable();

            DataRow row;

            //Add empty row
            table.Rows.Add(table.NewRow());

            //Add with value
            row = table.NewRow();
            row[1] = "Test data for row 2";
            //or
            row["Name"] = "Test data for row 2";
            table.Rows.Add(row);

            //Add object
            row = table.NewRow();
            table.Rows.Add( null, "Test data row 3" );
        }
    }



}
