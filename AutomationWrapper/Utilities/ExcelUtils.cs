using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWrapper.Utilities
{
   public class ExcelUtils
    {
        public static object[] GetSheetIntoTwoDimObjectArray(string fileDetail, string sheetname)
        {
            XLWorkbook book = new XLWorkbook(fileDetail);
            IXLWorksheet sheet = book.Worksheet(sheetname);
            IXLRange range = sheet.RangeUsed();
            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();
            object[] main = new object[rowCount - 1];
            for (int r = 2; r <= rowCount; r++)
            {
                //create temp object
                object[] temp = new object[colCount];
                for (int c = 1; c <= colCount; c++)
                {
                    //load temp object
                    temp[c - 1] = Convert.ToString(range.Cell(r, c).Value);
                }
                //add it to main object
                main[r - 2] = temp;
            }

            book.Dispose();

            return main;
        }

    }
}
