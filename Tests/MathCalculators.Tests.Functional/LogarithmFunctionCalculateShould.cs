using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class LogarithmFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateALogarithm()
        {
            var function = new LogarithmFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 8;
            inputs[1].Value = 3;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Log(8, 3), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateALogarithmWithOnlyBaseSpecified()
        {
            var function = new LogarithmFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[1].Value = 3;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Log(0, 3), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateALogarithmWithOnlyLogarithmSpecified()
        {
            var function = new LogarithmFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 8;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Log(8, 10), TypeConverter.ToObject<double>(i.Value));
                });
        }
    }
}
