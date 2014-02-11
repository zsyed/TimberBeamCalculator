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
            grades.Add(new TimberGrades() { TimberGrade = "C18", BendingParallelToGrain = 5.8, CompPerpendicularToGrain = 1.7, ShearParallelToGrain = 0.67, ModulusOfElasticityMean = 9100, ModulusOfElasticityMin = 6000, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C22", BendingParallelToGrain = 6.8, CompPerpendicularToGrain = 1.7, ShearParallelToGrain = 0.71, ModulusOfElasticityMean = 9700, ModulusOfElasticityMin = 6500, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C24", BendingParallelToGrain = 7.5, CompPerpendicularToGrain = 1.9, ShearParallelToGrain = 0.71, ModulusOfElasticityMean = 10800, ModulusOfElasticityMin = 7200, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C27", BendingParallelToGrain = 9.5, CompPerpendicularToGrain = 2.0, ShearParallelToGrain = 1.10, ModulusOfElasticityMean = 11500, ModulusOfElasticityMin = 8200, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C24", BendingParallelToGrain = 7.5, CompPerpendicularToGrain = 1.9, ShearParallelToGrain = 0.71, ModulusOfElasticityMean = 10800, ModulusOfElasticityMin = 7200, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C27", BendingParallelToGrain = 9.5, CompPerpendicularToGrain = 2.0, ShearParallelToGrain = 1.10, ModulusOfElasticityMean = 11500, ModulusOfElasticityMin = 8200, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C30", BendingParallelToGrain = 11.0, CompPerpendicularToGrain = 2.2, ShearParallelToGrain = 1.20, ModulusOfElasticityMean = 12300, ModulusOfElasticityMin = 8200, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C35", BendingParallelToGrain = 12.0, CompPerpendicularToGrain = 2.4, ShearParallelToGrain = 1.30, ModulusOfElasticityMean = 13400, ModulusOfElasticityMin = 9000, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "C40", BendingParallelToGrain = 13.0, CompPerpendicularToGrain = 2.6, ShearParallelToGrain = 1.40, ModulusOfElasticityMean = 14500, ModulusOfElasticityMin = 10000, TypeOfWood = WoodType.SoftWoods });
            grades.Add(new TimberGrades() { TimberGrade = "D30", BendingParallelToGrain = 9.0, CompPerpendicularToGrain = 2.2, ShearParallelToGrain = 1.40, ModulusOfElasticityMean = 9500, ModulusOfElasticityMin = 6000, TypeOfWood = WoodType.HardWoods });
            grades.Add(new TimberGrades() { TimberGrade = "D35", BendingParallelToGrain = 11.0, CompPerpendicularToGrain = 2.6, ShearParallelToGrain = 1.70, ModulusOfElasticityMean = 10000, ModulusOfElasticityMin = 6500, TypeOfWood = WoodType.HardWoods });
            grades.Add(new TimberGrades() { TimberGrade = "D40", BendingParallelToGrain = 12.5, CompPerpendicularToGrain = 3.0, ShearParallelToGrain = 2.00, ModulusOfElasticityMean = 10800, ModulusOfElasticityMin = 7500, TypeOfWood = WoodType.HardWoods });
            grades.Add(new TimberGrades() { TimberGrade = "D50", BendingParallelToGrain = 16.0, CompPerpendicularToGrain = 3.5, ShearParallelToGrain = 2.20, ModulusOfElasticityMean = 15000, ModulusOfElasticityMin = 12600, TypeOfWood = WoodType.HardWoods });
            grades.Add(new TimberGrades() { TimberGrade = "D60", BendingParallelToGrain = 18.0, CompPerpendicularToGrain = 4.0, ShearParallelToGrain = 2.40, ModulusOfElasticityMean = 18500, ModulusOfElasticityMin = 15600, TypeOfWood = WoodType.HardWoods });
            grades.Add(new TimberGrades() { TimberGrade = "D70", BendingParallelToGrain = 23.0, CompPerpendicularToGrain = 4.6, ShearParallelToGrain = 2.60, ModulusOfElasticityMean = 21000, ModulusOfElasticityMin = 18000, TypeOfWood = WoodType.HardWoods });
            grades.Add(new TimberGrades() { TimberGrade = "TH1", BendingParallelToGrain = 9.6, CompPerpendicularToGrain = 3.0, ShearParallelToGrain = 2.0, ModulusOfElasticityMean = 12500, ModulusOfElasticityMin = 8500, TypeOfWood = WoodType.Oaks });
            grades.Add(new TimberGrades() { TimberGrade = "TH2", BendingParallelToGrain = 7.8, CompPerpendicularToGrain = 3.0, ShearParallelToGrain = 2.0, ModulusOfElasticityMean = 10500, ModulusOfElasticityMin = 7000, TypeOfWood = WoodType.Oaks });
            grades.Add(new TimberGrades() { TimberGrade = "THA", BendingParallelToGrain = 12.6, CompPerpendicularToGrain = 3.0, ShearParallelToGrain = 2.0, ModulusOfElasticityMean = 13500, ModulusOfElasticityMin = 10500, TypeOfWood = WoodType.Oaks });
            grades.Add(new TimberGrades() { TimberGrade = "THB", BendingParallelToGrain = 9.1, CompPerpendicularToGrain = 3.0, ShearParallelToGrain = 2.0, ModulusOfElasticityMean = 12000, ModulusOfElasticityMin = 7500, TypeOfWood = WoodType.Oaks });

            return grades;
        }
    }
}


