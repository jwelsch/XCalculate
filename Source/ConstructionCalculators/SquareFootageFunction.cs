using System;
using XCalculateLib;

namespace ConstructionCalculators
{
    [Function]
    public class SquareFootageFunction : BaseFunction
    {
        private static readonly double InchesPerFoot = 12.0;

        public SquareFootageFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Square Footage", new ValueInfo("Area", "Calculated area.", new SquareFootUnit()), "Calculate square footage given feet and inches.", "construction", "area"),
                  new AgnosticValue(0.0, new ValueInfo("X Feet", "Number of feet along the X dimension.", new FootUnit())),
                  new AgnosticValue(0.0, new ValueInfo("X Inches", "Number of inches along the X dimension.", new InchUnit())),
                  new AgnosticValue(0.0, new ValueInfo("Y Feet", "Number of feet along the Y dimension.", new FootUnit())),
                  new AgnosticValue(0.0, new ValueInfo("Y Inches", "Number of inches along the Y dimension.", new InchUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var dimensionX = new FeetInchesDimension(TypeConverter.ToObject<double>(inputs[0].Value), TypeConverter.ToObject<double>(inputs[1].Value));
            var dimensionY = new FeetInchesDimension(TypeConverter.ToObject<double>(inputs[2].Value), TypeConverter.ToObject<double>(inputs[3].Value));

            var totalInchesX = GetTotalInches(dimensionX);
            var totalInchesY = GetTotalInches(dimensionY);

            var squareInches = totalInchesX * totalInchesY;

            var squareFeet = FromSquareInchesToSquareFeet(squareInches);

            return this.CreateResults(squareFeet);
        }

        private static double GetTotalInches(FeetInchesDimension dimension)
        {
            return FromFeetToInches(dimension.Feet) + dimension.Inches;
        }

        public static double FromFeetToInches(double feet)
        {
            return feet * InchesPerFoot;
        }

        public static double FromSquareInchesToSquareFeet(double squareInches)
        {
            return squareInches / InchesPerFoot / InchesPerFoot;
        }
    }
}
