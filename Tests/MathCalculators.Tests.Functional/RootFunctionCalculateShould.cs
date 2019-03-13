using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class RootFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateSquareRoot()
        {
            var function = new RootFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 9;
            inputs[1].Value = 2;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Sqrt(9), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculate5thRoot()
        {
            var function = new RootFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 8471;
            inputs[1].Value = 5;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Pow(8471, 1.0 / 5), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateRootWithOnlyRadicandSpecified()
        {
            var function = new RootFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = 16;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Pow(16, 1.0 / 2), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateRootWithOnlyIndexSpecified()
        {
            var function = new RootFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[1].Value = 3;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Pow(0, 1.0 / 2), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateRootWithNegativeValuesSpecified()
        {
            var function = new RootFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            inputs[0].Value = -10.0;
            inputs[1].Value = -3.0;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);
            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.Pow(-10.0, 1.0 / -3.0), TypeConverter.ToObject<double>(i.Value));
                });
        }
    }
}
