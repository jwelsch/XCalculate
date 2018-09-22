using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ModuloFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnWithDefaultValues()
        {
            var function = new ModuloFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(0, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsGreaterThanDivisor()
        {
            var function = new ModuloFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 17;
                p.Inputs[1].Value = 5;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(2, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsLessThanDivisor()
        {
            var function = new ModuloFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 5;
                p.Inputs[1].Value = 17;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(5, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsEqualToDivisor()
        {
            var function = new ModuloFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 17;
                p.Inputs[1].Value = 17;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(0, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailWhenGivenDivisorOfZero()
        {
            var function = new ModuloFunction();

            Assert.Throws<DivideByZeroException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = 17;
                    p.Inputs[1].Value = 0;

                    return p.Inputs;
                });
            });
        }
    }
}
