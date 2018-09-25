using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class FactorialFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnValueGivenAPositiveInteger()
        {
            var function = new FactorialFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 5;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(120, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnValueGivenAPositiveDouble()
        {
            var function = new FactorialFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 5.5;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(287.88527781504507, TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyReturnOneGivenZero()
        {
            var function = new FactorialFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 0;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailWhenGivenANegativeInteger()
        {
            var function = new FactorialFunction();

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
