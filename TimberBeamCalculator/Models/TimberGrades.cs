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

        public TimberGrades()
        {
            TimberGrade = "C14";
            BendingParallelToGrain = 4.1;
        }
    }
}