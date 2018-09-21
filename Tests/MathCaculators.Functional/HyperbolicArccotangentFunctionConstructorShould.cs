using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicArccotangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicArccotangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Arccotangent", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.Equal(3, function.FunctionInfo.Tags.Length);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
