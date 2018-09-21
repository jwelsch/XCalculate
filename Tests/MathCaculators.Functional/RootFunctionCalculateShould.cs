using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class RootFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateSquareRoot()
        {
            var function = new RootFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 9;
                p.Inputs[1].Value = 2;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Sqrt(9), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculate5thRoot()
        {
            var function = new RootFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8471;
                p.Inputs[1].Value = 5;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Pow(8471, 1.0 / 5), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateRootWithOnlyRadicandSpecified()
        {
            var function = new RootFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 16;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Pow(16, 1.0 / 2), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateRootWithOnlyIndexSpecified()
        {
            var function = new RootFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[1].Value = 3;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Pow(0, 1.0 / 3), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateRootWithNegativeValuesSpecified()
        {
            var function = new RootFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -10;
                p.Inputs[1].Value = -3;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Pow(-10, 1.0 / -3), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
