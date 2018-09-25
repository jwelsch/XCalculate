using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
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
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(0, TypeConverter.ToObject<int>(result.Value));
        }
    }
}
