using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace AddColumnToDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable("TestTable");
            
            //Add column using defaults
            DataColumn Col1 = new DataColumn("Col1");
            dt.Columns.Add( Col1 );
            PrintColumn( Col1 );

            //Add column defining type etc.
            DataColumn Col2 = new DataColumn( "Col2", typeof(long) );
            Col2.Unique = true;
            Col2.DefaultValue = 0;
            Col2.AllowDBNull = false;
            dt.Columns.Add( Col2 );
            PrintColumn(Col2);

            //Create Primary key
            DataColumn Col3 = new DataColumn( "Col3", typeof(int) );
            Col3.Unique = true;
            Col3.AllowDBNull = false;
            Col3.AutoIncrement = true;
            Col3.AutoIncrementSeed = -1;
            Col3.AutoIncrementStep = -1;
            dt.Columns.Add(Col3);
            PrintColumn(Col3);

            dt.PrimaryKey = new DataColumn[] { Col3 };            
        }

        static void PrintColumn( DataColumn col )
        {
            Console.WriteLine("ColumnName:{0}\n\tDataType:{1}\n\tMaxLenth:{2}\n\tUnique:{3}\n\tAllowDBNull:{4}\n\tCaption:{5}"
                ,col.ColumnName
                ,col.DataType.ToString()
                ,col.MaxLength
                ,col.Unique
                ,col.AllowDBNull
                ,col.Caption);
        }

    }
}
