using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class ExponentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateAnExponent()
        {
            var function = new ExponentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8;
                p.Inputs[1].Value = 3;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(512, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateAnExponentWithOnlyBaseSpecified()
        {
            var function = new ExponentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateAnExponentWithOnlyExponentSpecified()
        {
            var function = new ExponentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[1].Value = 3;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(0, TypeConverter.ToObject<int>(result.Value));
        }
    }
}
