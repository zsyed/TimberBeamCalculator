using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RazorPDF;

namespace TimberBeamCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Id)
        {
            return RedirectToAction("Pdf");
        }

        public PdfResult Pdf()
        {
            // With no Model and default view name.  Pdf is always the default view name
            return new PdfResult();
        }

    }
}
