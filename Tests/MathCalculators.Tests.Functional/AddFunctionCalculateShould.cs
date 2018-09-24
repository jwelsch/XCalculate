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

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 1, 2, 3 };
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(6, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailToAddASingleNumber()
        {
            var function = new AddFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = new int[] { 3 };
                });
            });
        }
    }
}
