using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class MultiplyFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyMultiplyNumbers()
        {
            var function = new MultiplyFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 100, 2, 3 };

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(600, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailToMultiplyASingleNumber()
        {
            var function = new MultiplyFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = new int[] { 3 };

                    return p.Inputs;
                });
            });
        }
    }
}
