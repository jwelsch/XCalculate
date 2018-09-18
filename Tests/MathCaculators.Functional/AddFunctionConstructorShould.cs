using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class AddFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new AddFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Add", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}
