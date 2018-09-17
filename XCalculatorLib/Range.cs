using System;

namespace XCalculatorLib
{
    public enum RangeInclusivity
    {
        AllInclusive,
        AllExclusive,
        MinimumInclusiveMaximumExclusive,
        MinimumExclusiveMaximumInclusive
    }

    public class Range
    {
        private int minimum = 0;
        private int maximum = 0;

        public int Minimum
        {
            get { return this.minimum; }
            set { this.SetValues(value, this.Maximum); }
        }

        public int Maximum
        {
            get { return this.maximum; }
            set { this.SetValues(value, this.Maximum); }
        }

        public RangeInclusivity Inclusivity
        {
            get;
            private set;
        }

        public Range(int minimum = 0, int maximum = 0, RangeInclusivity inclusivity = RangeInclusivity.AllInclusive)
        {
            this.SetValues(minimum, maximum);

            this.Inclusivity = inclusivity;
        }

        public void SetValues(int minimum, int maximum)
        {
            Validate(minimum, maximum);

            this.minimum = minimum;
            this.maximum = maximum;
        }

        private static void Validate(int minimum, int maximum, RangeInclusivity inclusivity = RangeInclusivity.AllInclusive)
        {
            if (minimum > maximum)
            {
                throw new ArgumentException($"The minimum must be less than or equal to the maximum.  Minimum was {minimum}.  Maximum was {maximum}.");
            }
        }

        public void Within(int value)
        {
            if (!this.TryWithin(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public bool TryWithin(int value)
        {
            return (this.Inclusivity == RangeInclusivity.AllInclusive && value >= this.Minimum && value <= this.Maximum)
                || (this.Inclusivity == RangeInclusivity.AllExclusive && value > this.Minimum && value < this.Maximum)
                || (this.Inclusivity == RangeInclusivity.MinimumExclusiveMaximumInclusive && value > this.Minimum && value <= this.Maximum)
                || (this.Inclusivity == RangeInclusivity.MinimumInclusiveMaximumExclusive && value >= this.Minimum && value < this.Maximum);
        }
    }
}