using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicTangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicTangentOfPositiveAngle()
        {
            var function = new HyperbolicTangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Tanh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicTangentOfNegativeAngle()
        {
            var function = new HyperbolicTangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Tanh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicTangentWithNoAngleSpecified()
        {
            var function = new HyperbolicTangentFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Tanh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
