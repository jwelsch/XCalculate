using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class LogarithmFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new LogarithmFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Logarithm", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
