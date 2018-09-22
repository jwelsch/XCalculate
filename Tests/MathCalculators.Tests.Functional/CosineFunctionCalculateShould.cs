using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class CosineFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateCosineOfPositiveAngle()
        {
            var function = new CosineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Cos(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateCosineOfNegativeAngle()
        {
            var function = new CosineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Cos(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateCosineWithNoAngleSpecified()
        {
            var function = new CosineFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Cos(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
