using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryForOptimization.Excel.structureForExcel;
using OfficeOpenXml;

namespace LibraryForOptimization.Excel
{
    /// <summary>
    /// 
    /// </summary>
    public static class WorkWithExcelExport
    {
        public static void SaveToExcel(DataGridView dataGrid)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dataGrid.Columns)
                {
                    dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in dataGrid.Rows)

                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt.Rows.Add(dRow);
                }
                //create a new Worksheet
                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                //add some text to cell A1
                //worksheet.Cells["A1"].Value = "My fourth EPPlus spreadsheet!";
                addData(excelPackage, dt);
                //create a SaveFileDialog instance with some properties
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save Excel sheet";
                saveFileDialog1.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog1.FileName = "Расчет_" + DateTime.Now.ToString("dd-MM-yyyy HH:mm") + ".xlsx";

                //check if user clicked the save button
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Get the FileInfo
                    FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                    //write the file to the disk
                    excelPackage.SaveAs(fi);
                }
            }
        }

        private static void addData(ExcelPackage package, DataTable data)
        {
            package.Workbook.Worksheets.Add("Лист 1");
            package.Workbook.Worksheets["Лист 1"].Cells["A1"].LoadFromDataTable(data, true);
        }
      


        
    }
}

