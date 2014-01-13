using System;
using System.Collections.Generic;
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
            return RedirectToAction("Pdf", d);
        }

        public PdfResult Pdf(Dimensions d)
        {
            d.ProjectTitle = "Timber Beam Project Report.";
            // With no Model and default view name.  Pdf is always the default view name
            return new PdfResult(d);
        }

    }
}
