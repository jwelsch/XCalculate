using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class LogarithmFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new LogarithmFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Logarithm", function.FunctionInfo.Name);
            Assert.Equal("Find the logarithm of a number.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("logarithm", i));
        }
    }
}
