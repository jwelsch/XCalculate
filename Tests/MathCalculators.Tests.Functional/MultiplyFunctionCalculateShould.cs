using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class MultiplyFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyMultiplyNumbers()
        {
            var function = new MultiplyFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = new[] { 100, 2, 3 };

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(600, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void FailToMultiplyASingleNumber()
        {
            var function = new MultiplyFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var inputs = function.GetInputs();

                inputs[0].Value = new[] { 1 };

                var result = function.Calculate(inputs);
            });
        }
    }
}
