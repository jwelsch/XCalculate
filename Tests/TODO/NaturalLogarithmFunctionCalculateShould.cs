using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class NaturalLogarithmFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnWithDefaultValues()
        {
            var function = new NaturalLogarithmFunction();

            var phase = function.Calculate();

            Assert.NotNull(phase);
            Assert.Equal("Specify Arguments", phase.Name);
            Assert.Equal("Specify natural logarithm argument.", phase.Description);
            Assert.Collection(phase.Inputs,
                i =>
                {
                    Assert.Equal("Argument", i.Info.Name);
                    Assert.Equal("Argument to the natural logarithm.", i.Info.Description);
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
        public void SuccessfullyReturnGivenPositiveValue()
        {
            var function = new NaturalLogarithmFunction();

            var phase = function.Calculate();

            phase.Inputs[0].Value = 27.3;

            function.Calculate(phase);

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(3.3068867021909143, TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void FailWhenGivenZero()
        {
            var function = new NaturalLogarithmFunction();

            var phase = function.Calculate();

            Assert.Throws<ArgumentException>(() =>
            {
                phase.Inputs[0].Value = 0;
            });
        }

        [Fact]
        public void FailWhenGivenLessThanZero()
        {
            var function = new NaturalLogarithmFunction();

            var phase = function.Calculate();

            Assert.Throws<ArgumentException>(() =>
            {
                phase.Inputs[0].Value = -1;
            });
        }
    }
}
