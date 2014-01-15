using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RazorPDF;
using TimberBeamCalculator.Models;

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
            string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\";", filename);
            string query = String.Format("SELECT * from [{0}$]", "myRange1");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable YourTable = dataSet.Tables[0];
            d.PermanentLoadSafetyFactor = Convert.ToDouble(YourTable.Rows[0][0]);
            d.SpanLength = Convert.ToDouble(YourTable.Rows[0][1]);
            d.VariableLoadSafetyFactor = Convert.ToDouble(YourTable.Rows[0][2]);


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
