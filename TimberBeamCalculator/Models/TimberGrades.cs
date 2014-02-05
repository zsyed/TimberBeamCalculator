using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimberBeamCalculator.Models
{
    public class TimberGrades
    {
        public string TimberGrade { get; set; }
        public double BendingParallelToGrain { get; set; }
        public double CompPerpendicularToGrain { get; set; }
        public double ShearParallelToGrain { get; set; }
        public int ModulusOfElasticityMean { get; set; }
        public int ModulusOfElasticityMin { get; set; }
        public bool SoftWood { get; set; }
    }
}