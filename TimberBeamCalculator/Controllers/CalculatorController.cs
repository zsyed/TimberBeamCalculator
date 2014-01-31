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
using System.Collections;
using ClosedXML.Excel;
using iTextSharp.text.pdf;
using DocumentFormat.OpenXml.Wordprocessing;


namespace TimberBeamCalculator.Controllers
{

    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ActionResult Index()
        {
            var dim = new TimberBeamCalculator.Models.Dimensions();

            
            return View(dim);
        }

        [HttpPost]
        public ActionResult Index(TimberBeamCalculator.Models.Dimensions dim)
        {

 
            dim.JobNumber = 157;
            dim.ProjectTitle = "Denby House Business Centre";
            dim.ProjectDescription = "Timber Beam 1";
            dim.TimberGrade = "C16";
            dim.ProjectDate = DateTime.Now.ToShortDateString();

            dim.BendingParallelToGrain = 5.3;
            dim.CompPrependicularToGrain = 1.7;
            dim.ShearParallelToGrain = 0.67;
            dim.ModulusOfElasticityMean = 8800;
            dim.ModulusOfElasticityMin = 5800;
            
            dim.LoadIncludesRoofLoadingUse = false;
            dim.BeamCompriseOfTwoOrMorePiecesConnectedTogetherInParallel = false;
            if (dim.LoadIncludesRoofLoadingUse == true)
            {
                dim.DurationOfLoadK3 = 1.25;
            }
            else
            {
                dim.DurationOfLoadK3 = 1.0;
            }
            if (dim.BeamCompriseOfTwoOrMorePiecesConnectedTogetherInParallel == true)
            {
                dim.ModulusOfElasticityK8 = 1.1;
                if (dim.PieceCountModulusOfElasticity == ModulusPieceCount.TwoPieces)
                {
                    if (dim.TimberGradeWoodType == WoodType.SoftWood)
                    {
                        dim.ModulusOfElasticityK9 = 1.14;
                    }
                    else
                    {
                        dim.ModulusOfElasticityK9 = 1.06;
                    }
                }
                else if (dim.PieceCountModulusOfElasticity == ModulusPieceCount.ThreePieces)
                {
                    if (dim.TimberGradeWoodType == WoodType.SoftWood)
                    {
                        dim.ModulusOfElasticityK9 = 1.21;
                    }
                    else
                    {
                        dim.ModulusOfElasticityK9 = 1.08;
                    }
                }
                else
                {
                    if (dim.TimberGradeWoodType == WoodType.SoftWood)
                    {
                        dim.ModulusOfElasticityK9 = 1.24;
                    }
                    else
                    {
                        dim.ModulusOfElasticityK9 = 1.10;
                    }
                }
            }
            else
            {
                dim.ModulusOfElasticityK8 = 1.0;
                dim.ModulusOfElasticityK9 = 1.0;

            }
            dim.AllowableShearStressResult = dim.ShearParallelToGrain * dim.DurationOfLoadK3 * dim.ModulusOfElasticityK8;
            // Create excel sheet with one cell as an output of sum of 3 numbers.
            return RedirectToAction("Pdf", dim);
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


////////string filename;
////////string path = Server.MapPath("/"); 

////////filename = path + "TimberBeamData.xlsx";

////////var workbook = new XLWorkbook(filename);
////////var ws = workbook.Worksheet(1);

////////string s = ws.Cell("C4").FormulaA1;

////////var c1 = Convert.ToDouble(d.PermanentLoadSafetyFactor.ToString());
////////var c2 = Convert.ToDouble(d.SpanLength.ToString());
////////ws.Cell("C2").SetValue(c1).CellBelow().SetValue(c1); 
////////ws.Cell("C3").SetValue(c2).CellBelow().SetValue(c2);
////////ws.Cell("C4").FormulaA1 =s ;

////////workbook.Save();

////////d.FinalResult = Convert.ToDouble(ws.Cell("C4").GetString());
