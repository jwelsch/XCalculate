using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class LogarithmFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateAnLogarithm()
        {
            var function = new LogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8;
                p.Inputs[1].Value = 3;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Log(8, 3), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateAnLogarithmWithOnlyBaseSpecified()
        {
            var function = new LogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Log(8, 10), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateAnLogarithmWithOnlyLogarithmSpecified()
        {
            var function = new LogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[1].Value = 3;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Log(0, 3), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
