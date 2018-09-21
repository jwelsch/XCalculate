using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class RootFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new RootFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Root", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
