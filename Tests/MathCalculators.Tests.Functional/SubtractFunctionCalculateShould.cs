using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class SubtractFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullySubtractNumbers()
        {
            var function = new SubtractFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = new[] { 3, 2, 1 };

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
        public void FailToSubtractASingleNumber()
        {
            var function = new SubtractFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var inputs = function.GetInputs();

                inputs[0].Value = new[] { 1 };

                var result = function.Calculate(inputs);
            });
        }
    }
}
