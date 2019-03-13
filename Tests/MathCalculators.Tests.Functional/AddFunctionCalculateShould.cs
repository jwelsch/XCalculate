using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class AddFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyAddNumbers()
        {
            var function = new AddFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = new [] { 1, 2, 3 };

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(6, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void FailToAddASingleNumber()
        {
            var function = new AddFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var inputs = function.GetInputs();

                inputs[0].Value = new [] { 1 };

                var result = function.Calculate(inputs);
            });
        }
    }
}
