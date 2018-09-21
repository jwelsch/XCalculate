using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class DivideFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyDivideNumbers()
        {
            var function = new DivideFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 100, 2, 2 };

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(25, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailToDivideASingleNumber()
        {
            var function = new DivideFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = new int[] { 3 };

                    return p.Inputs;
                });
            });
        }

        [Fact]
        public void FailToDivideByZero()
        {
            var function = new DivideFunction();

            Assert.Throws<DivideByZeroException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = new int[] { 3, 0 };

                    return p.Inputs;
                });
            });
        }
    }
}
