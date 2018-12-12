using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMemoryDB
{
    class SimpleDataTable : DataTable
    {
        public SimpleDataTable()
        {
            CreateDB();
        }

        private void CreateDB()
        {
            TableName = "SimpleDataTable";
            AddColumns();
            AddTestData();
        }


        private void AddTestData()
        {
            DataRow row;
            row = NewRow();
            row["Company"] = "Comp1";
            row["Rate"] = "1,10";
            Rows.Add(row);

            row = NewRow();
            row["Company"] = "Comp2";
            row["Rate"] = "10,20";
            Rows.Add(row);

            row = NewRow();
            row["Company"] = "Comp3";
            row["Rate"] = "9,00";
            Rows.Add(row);
        }


        private void AddColumns()
        {
            Columns.Add(new DataColumn("Company", typeof(string)));
            Columns.Add(new DataColumn("Rate", typeof(string)));
        }

        public override String ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach( DataRow row in Rows)
            {
                result.Append( row["Company"] + ";" + row["Rate"] + "\n");
            }

            return result.ToString();
        }


        internal double MaxRate( )
        {
            return  Convert.ToDouble( Compute("max(Rate)", string.Empty ) );
        }

        internal double MaxRateDouble()
        {
            return Convert.ToDouble( Compute("max(RateDouble)", string.Empty) );
        }

        internal void AddColumnRateAsDouble()
        {
            Columns.Add( new DataColumn("RateDouble",typeof(Double)));
            foreach( DataRow row in Rows)
            {
                row["RateDouble"] = Convert.ToDouble(row["Rate"]);
            }
        }
        internal Double MaxRateUsingLinq()
        {
            List<Double> rate = this.AsEnumerable().Select(al => Convert.ToDouble(al.Field<String>("Rate"))).Distinct().ToList();
            return rate.Max();
        }

        internal Double MinRateUsingLinq()
        {
            List<Double> rates = this.AsEnumerable().Select(rows => Convert.ToDouble(rows.Field<String>("Rate"))).Distinct().ToList();
            return rates.Min();
        }

    }
}
