using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionCalculators
{
    internal class FeetInchesDimension
    {
        public double Feet
        {
            get;
        }

        public double Inches
        {
            get;
        }

        public FeetInchesDimension(double feet, double inches)
        {
            this.Feet = feet;
            this.Inches = inches;
        }
    }
}
