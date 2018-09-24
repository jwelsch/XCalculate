using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class NaturalLogarithmFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnWithDefaultValues()
        {
            var function = new NaturalLogarithmFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(0, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnGivenPositiveValue()
        {
            var function = new NaturalLogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 27.3;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(3.3068867021909143, TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void FailWhenGivenZero()
        {
            var function = new NaturalLogarithmFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = 0;
                });
            });
        }

        [Fact]
        public void FailWhenGivenLessThanZero()
        {
            var function = new NaturalLogarithmFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = -9;
                });
            });
        }
    }
}
