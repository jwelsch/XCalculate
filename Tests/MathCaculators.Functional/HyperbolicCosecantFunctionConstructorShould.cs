using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicCosecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicCosecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Cosecant", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.Equal(3, function.FunctionInfo.Tags.Length);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
