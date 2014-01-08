using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimberBeamCalculator.Models
{
    public class Dimensions
    {
        public double SpanLength { get; set; }
        public double VariableLoadSafetyFactor { get; set; }
        public double PermanentLoadSafetyFactor { get; set; }
    }
}