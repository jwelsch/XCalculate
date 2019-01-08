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

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsGreaterThanDivisor()
        {
            var function = new ModuloFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 17;
            inputs[1].Value = 5;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(2, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsLessThanDivisor()
        {
            var function = new ModuloFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 5;
            inputs[1].Value = 17;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(5, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsEqualToDivisor()
        {
            var function = new ModuloFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 17;
            inputs[1].Value = 17;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void FailWhenGivenDivisorOfZero()
        {
            var function = new ModuloFunction();

            var inputs = function.GetInputs();

            Assert.Throws<DivideByZeroException>(() =>
            {
                inputs[0].Value = 17;
                inputs[1].Value = 0;
            });
        }
    }
}
