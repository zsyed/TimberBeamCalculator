using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimberBeamCalculator.Models
{
    public enum WoodType
    {
        Softwoods,
        Hardwoods,
        Oaks
    }

    public enum ModulusPieceCount
    {   TwoPieces,
        ThreePieces,
        FourPlusPieces
    }

    public class Dimensions
    {
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public int JobNumber { get; set; }
        public string ProjectDate { get; set; }
        public double BeamSpanLength { get; set; }
        public int WidthOfTimberBeam { get; set; }
        public int DepthOfTimberBeam { get; set; }
        public string TimberGrade { get; set; }
        public double BendingParallelToGrain { get; set; }
        public double CompPrependicularToGrain { get; set; }
        public double ShearParallelToGrain { get; set; }
        public double AllowableShearStressResult { get; set; }
        public int ModulusOfElasticityMean { get; set; }
        public int ModulusOfElasticityMin { get; set; }
        public double DurationOfLoadK3 { get; set; }
        public bool LoadIncludesRoofLoadingUse { get; set; }
        public WoodType TimberGradeWoodType { get; set; }
        public bool BeamCompriseOfTwoOrMorePiecesConnectedTogetherInParallel { get; set; }
        public ModulusPieceCount PieceCountModulusOfElasticity { get; set; }
        public double ModulusOfElasticityK8 { get; set; }
        public double ModulusOfElasticityK9 { get; set; }
        public string NameOfTheLoad { get; set; }
        public double PermanentLoad { get; set; }
        public double VariableLoad { get; set; }
    }
}