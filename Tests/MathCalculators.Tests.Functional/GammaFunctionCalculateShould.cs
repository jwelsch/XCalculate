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

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 5;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(24, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnValueGivenAPositiveDouble()
        {
            var function = new GammaFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 5.5;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(52.342777784553583, TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnNaNGivenZero()
        {
            var function = new GammaFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 0;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.True(Double.IsNaN(TypeConverter.ToObject<double>(result.Value)));
        }

        [Fact]
        public void FailWhenGivenANegativeInteger()
        {
            var function = new GammaFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = -5;
                });
            });
        }
    }
}
