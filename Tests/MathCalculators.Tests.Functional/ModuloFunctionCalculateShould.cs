using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ModuloFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnWithDefaultValues()
        {
            var function = new ModuloFunction();

            var phase = function.Calculate();

            Assert.NotNull(phase);
            Assert.Equal("Specify Operands", phase.Name);
            Assert.Equal("Specify the operands of the modulo operation.", phase.Description);
            Assert.Collection(phase.Inputs,
                i =>
                {
                    Assert.Equal("a", i.Info.Name);
                    Assert.Equal("Dividend value.", i.Info.Description);
                    Assert.Null(i.Info.Unit);
                },
                i =>
                {
                    Assert.Equal("n", i.Info.Name);
                    Assert.Equal("Divisor value.", i.Info.Description);
                    Assert.Null(i.Info.Unit);
                });

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsGreaterThanDivisor()
        {
            var function = new ModuloFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = 17;
            phase.Inputs[1].Value = 5;

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(2, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsLessThanDivisor()
        {
            var function = new ModuloFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = 5;
            phase.Inputs[1].Value = 17;

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(5, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyReturnValueGivenDividendIsEqualToDivisor()
        {
            var function = new ModuloFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = 17;
            phase.Inputs[1].Value = 17;

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void FailWhenGivenDivisorOfZero()
        {
            var function = new ModuloFunction();

            var phase = function.Calculate();

            Assert.Throws<DivideByZeroException>(() =>
            {
                phase.Inputs[0].Value = 17;
                phase.Inputs[1].Value = 0;
            });
        }
    }
}
