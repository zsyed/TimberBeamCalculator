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
using System.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace TimberBeamCalculator.Controllers
{

    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ActionResult Index()
        {
            var dim = new TimberBeamCalculator.Models.Dimensions() { PermanentLoadSafetyFactor = 3.3, SpanLength = 4.2, VariableLoadSafetyFactor = 7.6 }; 
            return View(dim);
        }

        private void SaveNumberToCell(string fileName, string sheetName, string cellCoordinates, string value)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, true))
            {


                Sheet sheet = document.WorkbookPart.Workbook.Descendants<Sheet>().SingleOrDefault(s => s.Name == sheetName);
                if (sheet == null)
                {
                    throw new ArgumentException(
                        String.Format("No sheet named {0} found in spreadsheet {1}", "myRange1", "myfile"), "sheetName");
                }
                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);


                int rowIndex = int.Parse(cellCoordinates.Substring(1));

                Row row = worksheetPart.Worksheet.GetFirstChild<SheetData>().
                        Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);

                Cell cell3 = row.Elements<Cell>().FirstOrDefault(c => cellCoordinates.Equals(c.CellReference.Value));
                if (cell3 != null)
                {
                    cell3.CellValue = new CellValue(value);
                    cell3.DataType = new DocumentFormat.OpenXml.EnumValue<CellValues>(CellValues.Number);
                }

                worksheetPart.Worksheet.Save();
                document.Close();

            }
        }

        [HttpPost]
        public ActionResult Index(TimberBeamCalculator.Models.Dimensions d)
        {
            string filename;
            string path = Server.MapPath("/"); 
            
            filename = path + "TimberBeamData.xlsx";

            SaveNumberToCell(filename, "myRange1", "C2", d.PermanentLoadSafetyFactor.ToString());
            SaveNumberToCell(filename, "myRange1", "C3", d.SpanLength.ToString());
            SaveNumberToCell(filename, "myRange1", "C4", d.VariableLoadSafetyFactor.ToString());

  

            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(Path.GetFullPath(filename));
            workbook.Close(true);
            excelApp.Quit();

            // getting the result out of excel.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filename, false))
            {

                Sheet sheet = document.WorkbookPart.Workbook.Descendants<Sheet>().SingleOrDefault(s => s.Name == "myRange1");
                if (sheet == null)
                {
                    throw new ArgumentException(
                        String.Format("No sheet named {0} found in spreadsheet {1}", "myRange1", filename), "sheetName");
                }



                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);

                int rowIndex = int.Parse("C5".Substring(1));

                Row row = worksheetPart.Worksheet.GetFirstChild<SheetData>().
                        Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);

                Cell cell = row.Elements<Cell>().FirstOrDefault(c => "C5".Equals(c.CellReference.Value));

                d.FinalResult = Convert.ToDouble(cell.CellValue.InnerText);

            }

            return RedirectToAction("Pdf", d);
        }

        public PdfResult Pdf(TimberBeamCalculator.Models.Dimensions d)
        {
            d.ProjectTitle = "Timber Beam Project Detailed Report.";
            // this should open the pdf in new window.
            Response.AddHeader("content-disposition", "attachment; filename=YourSanitazedFileName.pdf");
            // With no Model and default view name.  Pdf is always the default view name
            return new PdfResult(d);
        }
 

    }
}


