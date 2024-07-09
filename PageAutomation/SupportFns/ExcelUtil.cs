using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;
using NUnit.Framework;

namespace PageAutomation.SupportFns{
    
    class ExcelUtil
    {
        
        public static List<Datacollection> dataCol = new List<Datacollection>();

        public static DataTable ExcelToDataTable(string fileName)
        {
            String projectDir = (Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).ToString();
            projectDir = projectDir.Replace("\\bin\\Debug", "\\");
            fileName = projectDir + fileName;
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //Get all the Tables
                    DataTableCollection table = result.Tables;
                    //Store it in DataTable
                    DataTable resultTable = table["Credentials"];
                    //return
                    return resultTable;
                }
            }

        }

        /// <summary>
        /// Populate the data in collection
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        testname = table.Rows[row-1][0].ToString(),
                        colValue = table.Rows[row - 1][col].ToString()

                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }

        /// <summary>
        /// Read data from Collection
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            { 
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Read data from Collection using the TestcaseName
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ReadTestData(string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string testName = testDetails.testMethodName;
                string data = (from colData in dataCol
                               where colData.testname == testName && colData.colName == columnName
                               select colData.colValue).SingleOrDefault();
                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }


//Custom Class: (RowNumber, Column Name, Column Value:
public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
        public string testname { get; set; }
    }
}
