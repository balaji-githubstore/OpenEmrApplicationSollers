using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;

namespace OpenEmrApplication
{
    class DemoTest
    {
        [Test]
        public void ExcelRead()
        {
            XLWorkbook book = new XLWorkbook(@"D:\B-Mine\Company\Company\Sollers\OpenEmrApplication\OpenEmrApplication\TestData\OpenEMRData.xlsx");
            IXLWorksheet sheet = book.Worksheet("InvalidCredentialTest");
            IXLRange range=  sheet.RangeUsed();

            int rowCount = range.RowCount();
            Console.WriteLine(rowCount);
            int colCount = range.ColumnCount();
            Console.WriteLine(colCount);
            string cellValue= Convert.ToString(range.Cell(1, 1).Value);

            Console.WriteLine(cellValue);
            
            book.Dispose();
        }


        //john,john123
        //peter,peter123
        //mark,mark123

        //how many testcase? --> how many temp object and size of main object
        //how many parameter in each testcase? --> size of tempobject
        public static object[] ValidData()
        {
            object[] temp1 = new object[2];
            temp1[0] = "john";
            temp1[1] = "john123";

            object[] temp2 = new object[2];
            temp2[0] = "peter";
            temp2[1] = "peter123";

            object[] temp3 = new object[2];
            temp3[0] = "mark";
            temp3[1] = "mark123";

            object[] main = new object[3];
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }

        [Test,TestCaseSource("ValidData"),Ignore("Demo Method")]
        public void ValidTest(string username,string password)
        {
            Console.WriteLine(username+password);
        }
    }
}
