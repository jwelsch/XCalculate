using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class ArccosineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArccosineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arccosine", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.Equal(2, function.FunctionInfo.Tags.Length);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
