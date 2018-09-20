using MathCalculators;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class AddFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyAddNumbers()
        {
            var function = new AddFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 1, 2, 3 };

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(6, TypeConverter.ToObject<int>(result.Value));
        }
    }
}
