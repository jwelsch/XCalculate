using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicArcsineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicArcsineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Arcsine", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.Equal(3, function.FunctionInfo.Tags.Length);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
