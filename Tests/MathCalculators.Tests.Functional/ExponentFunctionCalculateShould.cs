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
            var inputs = function.GetInputs();

            Assert.NotNull(inputs);

            Assert.Collection(inputs,
                i =>
                {
                    Assert.Equal("Base", i.Info.Name);
                    Assert.Null(i.Info.Description);
                    Assert.Null(i.Info.Unit);
                },
                i =>
                {
                    Assert.Equal("Exponent", i.Info.Name);
                    Assert.Null(i.Info.Description);
                    Assert.Null(i.Info.Unit);
                });

            inputs[0].Value = 8;
            inputs[1].Value = 3;

            var result = function.Calculate(inputs);

            Assert.NotNull(result);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.GetValueType());
                    Assert.Equal(512, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateAnExponentWithOnlyBaseSpecified()
        {
            var function = new ExponentFunction();
            var inputs = function.GetInputs();

            Assert.NotNull(inputs);

            inputs[0].Value = 8;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.GetValueType());
                    Assert.Equal(1, TypeConverter.ToObject<int>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateAnExponentWithOnlyExponentSpecified()
        {
            var function = new ExponentFunction();
            var inputs = function.GetInputs();

            Assert.NotNull(inputs);

            inputs[1].Value = 3;

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.GetValueType());
                    Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
                });
        }
    }
}
