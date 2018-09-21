using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class TangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateTangentOfPositiveAngle()
        {
            var function = new TangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Tan(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateTangentOfNegativeAngle()
        {
            var function = new TangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Tan(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateTangentWithNoAngleSpecified()
        {
            var function = new TangentFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Tan(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
