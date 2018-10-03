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

            var phase = function.Calculate();

            Assert.NotNull(phase);
            Assert.Equal("Specify Operands", phase.Name);
            Assert.Equal("Specify root operation values.", phase.Description);
            Assert.Collection(phase.Inputs,
                i =>
                {
                    Assert.Equal("Radicand", i.Info.Name);
                    Assert.Null(i.Info.Description);
                    Assert.Null(i.Info.Unit);
                },
                i =>
                {
                    Assert.Equal("Index", i.Info.Name);
                    Assert.Null(i.Info.Description);
                    Assert.Null(i.Info.Unit);
                });

            phase.Inputs[0].Value = 9;
            phase.Inputs[1].Value = 2;

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(Math.Sqrt(9), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculate5thRoot()
        {
            var function = new RootFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = 8471;
            phase.Inputs[1].Value = 5;

            function.Calculate(phase);

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(Math.Pow(8471, 1.0 / 5), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateRootWithOnlyRadicandSpecified()
        {
            var function = new RootFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = 16;

            function.Calculate(phase);

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(Math.Pow(16, 1.0 / 2), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateRootWithOnlyIndexSpecified()
        {
            var function = new RootFunction();

            var phase = function.Calculate();

            phase.Inputs[1].Value = 3;

            function.Calculate(phase);

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(Math.Pow(0, 1.0 / 3), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateRootWithNegativeValuesSpecified()
        {
            var function = new RootFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = -10;
            phase.Inputs[1].Value = -3;

            function.Calculate(phase);

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(Math.Pow(-10, 1.0 / -3), TypeConverter.ToObject<double>(i.Value));
                });
        }
    }
}
