using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class DivideFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyDivideNumbers()
        {
            var function = new DivideFunction();

            var inputs = function.GetInputs();

            Assert.Single(inputs);

            inputs[0].Value = new [] { 100, 4, 2 };

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.GetValueType());
                    Assert.Equal(12.5, TypeConverter.ToObject<double>(i.Value));
                },
                i =>
                {
                    Assert.Equal(typeof(int), i.GetValueType());
                    Assert.Equal(12, TypeConverter.ToObject<int>(i.Value));
                },
                i =>
                {
                    Assert.Equal(typeof(int), i.GetValueType());
                    Assert.Equal(1, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void FailToDivideASingleNumber()
        {
            var function = new DivideFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var inputs = function.GetInputs();

                inputs[0].Value = new[] { 100 };

                var result = function.Calculate(inputs);
            });
        }

        [Fact]
        public void FailToDivideByZero()
        {
            var function = new DivideFunction();

            Assert.Throws<DivideByZeroException>(() =>
            {
                var inputs = function.GetInputs();

                inputs[0].Value = new int[] { 2, 0 };
            });
        }
    }
}
