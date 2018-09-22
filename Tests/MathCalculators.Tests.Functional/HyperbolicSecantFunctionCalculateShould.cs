using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicSecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicSecantOfPositiveAngle()
        {
            var function = new HyperbolicSecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Sinh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicSecantOfNegativeAngle()
        {
            var function = new HyperbolicSecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Sinh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicSecantWithNoAngleSpecified()
        {
            var function = new HyperbolicSecantFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Sinh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
