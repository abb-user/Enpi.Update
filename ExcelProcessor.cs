using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrification.ABB.SDK.EnPI.Update
{
    public class ExcelProcessor
    {

        public  async IAsyncEnumerable<string[]> ReadExcelAsync(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var package = new ExcelPackage(stream);

            var worksheet = package.Workbook.Worksheets[0]; // Assuming data is on the first worksheet

            // Determine the number of rows and columns in the worksheet
            var rowCount = worksheet.Dimension.Rows;
            var colCount = worksheet.Dimension.Columns;

            // Read rows asynchronously
            for (int row = 1; row <= rowCount; row++)
            {
                // Collect row data into a string array
                string[] rowData = new string[colCount];
                for (int col = 1; col <= colCount; col++)
                {
                    var cellValue = await Task.Run(() => worksheet.Cells[row, col].Value?.ToString() ?? string.Empty);
                    rowData[col - 1] = cellValue;
                }

                // Yield return the row data asynchronously
                yield return rowData;
            }

        }
    }
}
