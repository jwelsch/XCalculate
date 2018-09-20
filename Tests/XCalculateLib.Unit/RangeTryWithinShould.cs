using Xunit;

namespace XCalculateLib.Unit
{
    public class RangeTryWithinShould
    {
        private static readonly int RangeMinimum = 1;
        private static readonly int RangeMaximum = 10;

        // AllInclusive

        [Fact]
        public void ReturnTrueWhenAllInclusiveAndAtMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllInclusive);

            Assert.True(range.TryWithin(RangeMinimum));
        }

        [Fact]
        public void ReturnTrueWhenAllInclusiveAndAtMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllInclusive);

            Assert.True(range.TryWithin(RangeMaximum));
        }

        [Fact]
        public void ReturnFalseWhenAllInclusiveAndLessThanMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllInclusive);

            Assert.False(range.TryWithin(RangeMinimum - 1));
        }

        [Fact]
        public void ReturnFalseWhenAllInclusiveAndGreaterThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllInclusive);

            Assert.False(range.TryWithin(RangeMaximum + 1));
        }

        // AllExclusive

        [Fact]
        public void ReturnTrueWhenAllExclusiveAndGreaterThanMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllExclusive);

            Assert.True(range.TryWithin(RangeMinimum + 1));
        }

        [Fact]
        public void ReturnTrueWhenAllExclusiveAndLessThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllExclusive);

            Assert.True(range.TryWithin(RangeMaximum - 1));
        }

        [Fact]
        public void ReturnFalseWhenAllExclusiveAndAtMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllExclusive);

            Assert.False(range.TryWithin(RangeMinimum));
        }

        [Fact]
        public void ReturnFalseWhenAllExclusiveAndAtMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllExclusive);

            Assert.False(range.TryWithin(RangeMaximum));
        }

        [Fact]
        public void ReturnFalseWhenAllExclusiveAndLessThanMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllExclusive);

            Assert.False(range.TryWithin(RangeMinimum - 1));
        }

        [Fact]
        public void ReturnFalseWhenAllExclusiveAndGreaterThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.AllExclusive);

            Assert.False(range.TryWithin(RangeMaximum + 1));
        }

        // MinimumInclusiveMaximumExclusive

        [Fact]
        public void ReturnTrueWhenMinimumInclusiveMaximumExclusiveAndEqualToMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumInclusiveMaximumExclusive);

            Assert.True(range.TryWithin(RangeMinimum));
        }

        [Fact]
        public void ReturnTrueWhenMinimumInclusiveMaximumExclusiveAndLessThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumInclusiveMaximumExclusive);

            Assert.True(range.TryWithin(RangeMaximum - 1));
        }

        [Fact]
        public void ReturnFalseWhenMinimumInclusiveMaximumExclusiveAndAtMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumInclusiveMaximumExclusive);

            Assert.False(range.TryWithin(RangeMaximum));
        }

        [Fact]
        public void ReturnFalseWhenMinimumInclusiveMaximumExclusiveAndLessThanMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumInclusiveMaximumExclusive);

            Assert.False(range.TryWithin(RangeMinimum - 1));
        }

        [Fact]
        public void ReturnFalseWhenMinimumInclusiveMaximumExclusiveAndGreaterThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumInclusiveMaximumExclusive);

            Assert.False(range.TryWithin(RangeMaximum + 1));
        }

        // MinimumExclusiveMaximumInclusive

        [Fact]
        public void ReturnTrueWhenMinimumExclusiveMaximumInclusiveAndGreaterThanMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumExclusiveMaximumInclusive);

            Assert.True(range.TryWithin(RangeMinimum + 1));
        }

        [Fact]
        public void ReturnTrueWhenMinimumExclusiveMaximumInclusiveAndLessThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumExclusiveMaximumInclusive);

            Assert.True(range.TryWithin(RangeMaximum - 1));
        }

        [Fact]
        public void ReturnTrueWhenMinimumExclusiveMaximumInclusiveAndAtMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumExclusiveMaximumInclusive);

            Assert.True(range.TryWithin(RangeMaximum));
        }

        [Fact]
        public void ReturnFalseWhenMinimumExclusiveMaximumInclusiveAndLessThanMinimumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumExclusiveMaximumInclusive);

            Assert.False(range.TryWithin(RangeMinimum - 1));
        }

        [Fact]
        public void ReturnFalseWhenMinimumExclusiveMaximumInclusiveAndGreaterThanMaximumExtreme()
        {
            var range = new Range(RangeMinimum, RangeMaximum, RangeInclusivity.MinimumExclusiveMaximumInclusive);

            Assert.False(range.TryWithin(RangeMaximum + 1));
        }
    }
}
