using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RazorPDF;
using TimberBeamCalculator.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace TimberBeamCalculator.Controllers
{

    class ExampleData
    {
        public string KillingOccurance { get; set; }
        public int NumberResults { get; set; }

        public override string ToString()
        {
            return KillingOccurance.PadRight(8, ' ') + "\t\t\t | " + NumberResults.ToString().PadLeft(3, ' ');
        }
    }


    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ActionResult Index()
        {
            var dim = new Dimensions() { PermanentLoadSafetyFactor = 3.3, SpanLength = 4.2, VariableLoadSafetyFactor = 7.6 }; 
            return View(dim);
        }

        [HttpPost]
        public ActionResult Index(Dimensions d)
        {
            string filename = Server.MapPath("/") + "TimberBeamData.xlsx";
            const int startRow = 1;
            IList<double> exampleDataList = new List<double>();
                        // Get the file we are going to process
            var existingFile = new FileInfo(filename);
            // Open and read the XlSX file.
            using (var package = new ExcelPackage(existingFile))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        // read some data
                        object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                        object col2Header = currentWorksheet.Cells[startRow, 2].Value;

                        for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                        // read each row from the start of the data (start row + 1 header row) to the end of the spreadsheet.
                        {
                            var col1Value = Convert.ToDouble(currentWorksheet.Cells[rowNumber, 1].Value);
                            exampleDataList.Add(col1Value);
                        }


                    }
                }
            }

            d.PermanentLoadSafetyFactor = exampleDataList[0];
            d.SpanLength = exampleDataList[1];
            d.VariableLoadSafetyFactor = exampleDataList[2];

            //////string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\";", filename);
            //////string query = String.Format("SELECT * from [{0}$]", "myRange1");
            //////OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            //////DataSet dataSet = new DataSet();
            //////dataAdapter.Fill(dataSet);
            //////DataTable YourTable = dataSet.Tables[0];
            //////d.PermanentLoadSafetyFactor = Convert.ToDouble(YourTable.Rows[0][0]);
            //////d.SpanLength = Convert.ToDouble(YourTable.Rows[0][1]);
            //////d.VariableLoadSafetyFactor = Convert.ToDouble(YourTable.Rows[0][2]);


            return RedirectToAction("Pdf", d);
        }

        public PdfResult Pdf(Dimensions d)
        {
            d.ProjectTitle = "Timber Beam Project Detailed Report.";
            // this should open the pdf in new window.
            Response.AddHeader("content-disposition", "attachment; filename=YourSanitazedFileName.pdf");
            // With no Model and default view name.  Pdf is always the default view name
            return new PdfResult(d);
        }

    }
}
