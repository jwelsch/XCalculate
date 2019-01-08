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

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnGivenPositiveValue()
        {
            var function = new NaturalLogarithmFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = 27.3;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(3.3068867021909143, TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void FailWhenGivenZero()
        {
            var function = new NaturalLogarithmFunction();

            var inputs = function.GetInputs();

            Assert.Throws<ArgumentException>(() =>
            {
                inputs[0].Value = 0;
            });
        }

        [Fact]
        public void FailWhenGivenLessThanZero()
        {
            var function = new NaturalLogarithmFunction();

            var inputs = function.GetInputs();

            Assert.Throws<ArgumentException>(() =>
            {
                inputs[0].Value = -1;
            });
        }
    }
}
