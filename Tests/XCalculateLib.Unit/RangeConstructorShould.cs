using System;
using Xunit;

namespace XCalculateLib.Unit
{
    public class RangeConstructorShould
    {
        [Fact]
        public void SuccessfullyCreateObjectWithDefaultValues()
        {
            var range = new Range();

            Assert.NotNull(range);
            Assert.Equal(0, range.Minimum);
            Assert.Equal(0, range.Maximum);
            Assert.Equal(RangeInclusivity.AllInclusive, range.Inclusivity);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithSpecifiedValues()
        {
            var minimum = 1;
            var maximum = 100;
            var inclusivity = RangeInclusivity.AllExclusive;

            var range = new Range(minimum, maximum, inclusivity);

            Assert.NotNull(range);
            Assert.Equal(minimum, range.Minimum);
            Assert.Equal(maximum, range.Maximum);
            Assert.Equal(inclusivity, range.Inclusivity);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithEqualMinimumAndMaximum()
        {
            var minimum = 1;
            var maximum = minimum;

            var range = new Range(minimum, maximum);

            Assert.NotNull(range);
            Assert.Equal(minimum, range.Minimum);
            Assert.Equal(maximum, range.Maximum);
        }

        [Fact]
        public void FailWhenMinimumIsGreaterThanMaxium()
        {
            var minimum = 3;
            var maximum = minimum - 1;

            Assert.Throws<ArgumentException>(() =>
            {
                var range = new Range(minimum, maximum);
            });
        }
    }
}
