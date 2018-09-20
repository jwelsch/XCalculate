using MathCalculators;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class DivideFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyDivideNumbers()
        {
            var function = new DivideFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 100, 2, 2 };

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(25, TypeConverter.ToObject<int>(result.Value));
        }
    }
}
