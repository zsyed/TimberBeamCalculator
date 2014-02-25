using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimberBeamCalculator.Models
{
    public class LoadingDetails
    {
        public string NameOfLoad { get; set; }
        public double DeadLoad { get; set; }
        public double LiveLoad { get; set; }
    }
}