using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class GammaFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnValueGivenAPositiveInteger()
        {
            var function = new GammaFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = 5;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(24, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenAPositiveDouble()
        {
            var function = new GammaFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = 5.5;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(52.342777784553583, TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnNaNGivenZero()
        {
            var function = new GammaFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = 0;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.True(Double.IsNaN(TypeConverter.ToObject<double>(i.Value)));
                });
        }

        [Fact]
        public void FailWhenGivenANegativeInteger()
        {
            var function = new GammaFunction();

            var inputs = function.GetInputs();

            Assert.Throws<ArgumentException>(() =>
            {
                inputs[0].Value = -5;
            });
        }
    }
}
