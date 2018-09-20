using System;
using Xunit;

namespace XCalculateLib.Unit
{
    public class AgnosticArrayValueToArrayShould
    {
        [Fact]
        public void SuccessfullyReturnArrayOfSameType()
        {
            var defaultValue = new int[] { 1, 2, 3 };

            var value = new AgnosticArrayValue(defaultValue);

            var covertedArray = value.ToArray<int[]>();

            Assert.Collection(covertedArray,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.ValueType);
        }

        [Fact]
        public void SuccessfullyReturnArrayOfDifferentType()
        {
            var defaultValue = new int[] { 1, 2, 3 };

            var value = new AgnosticArrayValue(defaultValue);

            var covertedArray = value.ToArray<double[]>();

            Assert.Collection(covertedArray,
                i => Assert.Equal((double)defaultValue[0], i),
                i => Assert.Equal((double)defaultValue[1], i),
                i => Assert.Equal((double)defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.ValueType);
        }

        [Fact]
        public void FailToReturnObjectThatIsNotAnArrayType()
        {
            var defaultValue = new int[] { 1, 2, 3 };

            var value = new AgnosticArrayValue(defaultValue);

            Assert.Throws<ArgumentException>(() =>
            {
                var covertedArray = value.ToArray<double>();
            });
        }
    }
}
