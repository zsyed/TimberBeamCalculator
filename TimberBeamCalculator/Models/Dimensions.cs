using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimberBeamCalculator.Models
{
    public class Dimensions
    {
        public string ProjectTitle { get; set; }
        public double SpanLength { get; set; }
        public double VariableLoadSafetyFactor { get; set; }
        public double PermanentLoadSafetyFactor { get; set; }
        public double FinalResult { get; set; }
        public double Average { get; set; }
    }
}