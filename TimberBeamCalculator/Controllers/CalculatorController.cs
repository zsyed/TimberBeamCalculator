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

namespace TimberBeamCalculator.Controllers
{

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
            const int startCol = 0;
            List<double> exampleDataList = new List<double>();
            var finalResuls = new List<double>();
            var existingFile = new FileInfo(filename);
            using (var package = new ExcelPackage(existingFile))
            {
                ExcelWorkbook workBook = package.Workbook;
                var currentWorksheet = workBook.Worksheets.First();

                exampleDataList.AddRange(
                    Enumerable.Range(startRow + 1, currentWorksheet.Dimension.End.Row)
                    .Select(i => Convert.ToDouble(currentWorksheet.Cells[i, 1].Value))
                    );

                for (var index = startCol + 1; index <= currentWorksheet.Dimension.End.Column; ++index)
                {
                    if (currentWorksheet.Cells[4, index].Style.Font.Color.Rgb != null)
                    {
                        if (currentWorksheet.Cells[4, index].Style.Font.Color.Rgb.ToString() == "FFFF0000")
                        {
                            d.FinalResult = Convert.ToDouble(currentWorksheet.Cells[4, index].Value);
                        }
                    }
                }

            }

            d.PermanentLoadSafetyFactor = exampleDataList[0];
            d.SpanLength = exampleDataList[1];
            d.VariableLoadSafetyFactor = exampleDataList[2];


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
