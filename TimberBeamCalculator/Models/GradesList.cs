using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimberBeamCalculator.Models
{
    public static class Grades
    {
        public static List<TimberGrades> GetList()
        {
            var grades = new List<TimberGrades>();
            grades.Add(new TimberGrades() { TimberGrade = "C14", BendingParallelToGrain = 4.1 });
            grades.Add(new TimberGrades() { TimberGrade = "C16", BendingParallelToGrain = 5.3 });
            return grades;
        }
    }
}