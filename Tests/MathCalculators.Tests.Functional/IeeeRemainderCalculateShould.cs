using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class IeeeRemainderFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnWithDefaultValues()
        {
            var function = new IeeeRemainderFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.IEEERemainder(0.0, 1.0), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsGreaterThanDivisor()
        {
            var function = new IeeeRemainderFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 17;
            inputs[1].Value = 5;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.IEEERemainder(17, 5), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsLessThanDivisor()
        {
            var function = new IeeeRemainderFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 5;
            inputs[1].Value = 17;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.IEEERemainder(5, 17), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsEqualToDivisor()
        {
            var function = new IeeeRemainderFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 17;
            inputs[1].Value = 17;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.IEEERemainder(17, 17), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void FailWhenGivenDivisorOfZero()
        {
            var function = new IeeeRemainderFunction();

            var inputs = function.GetInputs();

            Assert.Throws<DivideByZeroException>(() =>
            {
                inputs[0].Value = 17;
                inputs[1].Value = 0;
            });
        }
    }
}
