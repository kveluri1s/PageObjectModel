using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageAutomation.SupportFns
{
    static class TableUtilities
    {
        static List<TableDataCollection> tableDataCollections = new List<TableDataCollection>();

        public static void ReadTable(IWebElement table)
        {
            //Get All the columns from the Webtable
            var columns = table.FindElements(By.TagName("th"));

            //Get All the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create Row Index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var ColValue in colDatas)
                {
                    tableDataCollections.Add(new TableDataCollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text,
                        ColumnValue = ColValue.Text
                    });

                    //Move to next Column
                    colIndex++;
                }
                //Move to next row
                rowIndex++;
            }

        }

        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in tableDataCollections
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();

            return data;

        }
        
    }

    public class TableDataCollection{

        public int RowNumber { get; set;}
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }

    }
}
