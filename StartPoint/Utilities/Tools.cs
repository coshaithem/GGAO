using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMultiColumnComboBox;

namespace GGAO.Utilities
{
    class Tools
    {
        public static string Spaces(byte length,char rep)
        {
            string start = "";
            for ( byte i = 1; i<= length; i++)
            {
                start += rep;
            }
            return start;
        }
        public static string[] ConvColNametoArray(DataColumnCollection columns )
        {
            // scrap column names of  the table
            List<string> ColumnNames = new List<string>();
            string collect = "";
            foreach (DataColumn DTC in columns )
            {
                ColumnNames.Add(DTC.ColumnName.Trim());
                collect += DTC.ColumnName.Trim() + " ";
            }

            return ColumnNames.ToArray(); ;
        }
    }

}
