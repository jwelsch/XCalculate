using System;
using Xunit;

namespace XCalculatorLib.Unit
{
    public class RangeSetValuesShould
    {
        [Fact]
        public void SuccessfullySetValuesWithValidInputs()
        {
            var minimum = 1;
            var maximum = 10;

            var range = new Range();

            range.SetValues(minimum, maximum);

            Assert.Equal(minimum, range.Minimum);
            Assert.Equal(maximum, range.Maximum);
        }

        [Fact]
        public void SuccessfullySetValuesWhenMinimumAndMaximumAreEqual()
        {
            var minimum = 10;
            var maximum = minimum;

            var range = new Range();

            range.SetValues(minimum, maximum);

            Assert.Equal(minimum, range.Minimum);
            Assert.Equal(maximum, range.Maximum);
        }

        [Fact]
        public void FailWhenMinimumIsGreaterThanMaximum()
        {
            var minimum = 10;
            var maximum = minimum - 1;

            var range = new Range();

            Assert.Throws<ArgumentException>(() =>
            {
                range.SetValues(minimum, maximum);
            });
        }
    }
}
