using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class MultiplyFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new MultiplyFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Multiply", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
