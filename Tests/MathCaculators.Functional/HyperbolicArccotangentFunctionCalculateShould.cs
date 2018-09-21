using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicArccotangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArccotangentOfPositiveAngle()
        {
            var function = new HyperbolicArccotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Atanh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccotangentOfNegativeAngle()
        {
            var function = new HyperbolicArccotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Atanh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccotangentWithNoAngleSpecified()
        {
            var function = new HyperbolicArccotangentFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Atanh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
