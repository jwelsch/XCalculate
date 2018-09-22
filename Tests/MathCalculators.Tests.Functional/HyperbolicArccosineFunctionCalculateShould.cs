using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArccosineFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicArccosineOfPositiveAngle()
        {
            var function = new HyperbolicArccosineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Acosh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicArccosineOfNegativeAngle()
        {
            var function = new HyperbolicArccosineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Acosh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicArccosineWithNoAngleSpecified()
        {
            var function = new HyperbolicArccosineFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Acosh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
