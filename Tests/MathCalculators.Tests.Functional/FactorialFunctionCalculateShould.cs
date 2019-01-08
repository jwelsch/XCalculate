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

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = 5;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(120, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenAPositiveDouble()
        {
            var function = new FactorialFunction();

            var inputs = function.GetInputs();

            inputs[0].Value = 5.5;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(287.88527781504507, TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnOneGivenZero()
        {
            var function = new FactorialFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = 0;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(1, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void FailWhenGivenANegativeInteger()
        {
            var function = new FactorialFunction();

            var inputs = function.GetInputs();

            Assert.Throws<ArgumentException>(() =>
            {
                inputs[0].Value = -5;
            });
        }
    }
}
