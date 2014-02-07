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
            grades.Add(new TimberGrades() { TimberGrade = "C14", BendingParallelToGrain = 4.1, CompPerpendicularToGrain = 1.6, ShearParallelToGrain = 0.60, ModulusOfElasticityMean=6800, ModulusOfElasticityMin = 4600, TypeOfWood = WoodType.SoftWoods});
            grades.Add(new TimberGrades() { TimberGrade = "C16", BendingParallelToGrain = 5.3, CompPerpendicularToGrain = 1.7, ShearParallelToGrain = 0.67, ModulusOfElasticityMean = 8800, ModulusOfElasticityMin = 5800, TypeOfWood = WoodType.SoftWoods });

            return grades;
        }
    }
}