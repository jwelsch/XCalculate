using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class DivideFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new DivideFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Divide", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
