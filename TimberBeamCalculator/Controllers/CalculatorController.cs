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

        [HttpPost]
        public ActionResult Index(TimberBeamCalculator.Models.Dimensions d)
        {
            string filename = Server.MapPath("/") + "TimberBeamData.xlsx";

            // getting the result out of excel.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filename, true))
            {
                document.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                document.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;

                Sheet sheet = document.WorkbookPart.Workbook.Descendants<Sheet>().SingleOrDefault(s => s.Name == "myRange1");
                if (sheet == null)
                {
                    throw new ArgumentException(
                        String.Format("No sheet named {0} found in spreadsheet {1}", "myRange1", filename), "sheetName");
                }
                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);

                int rowIndex = int.Parse("C4".Substring(1));

                Row row = worksheetPart.Worksheet.GetFirstChild<SheetData>().
                        Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);
 
                Cell cell = row.Elements<Cell>().FirstOrDefault(c => "C4".Equals(c.CellReference.Value));
                d.Average = Convert.ToDouble(cell.CellValue.InnerText);
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

