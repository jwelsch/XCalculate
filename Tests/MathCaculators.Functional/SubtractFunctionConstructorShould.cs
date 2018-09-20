using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class SubtractFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new SubtractFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Subtract", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
