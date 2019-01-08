using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class MultiplyFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new MultiplyFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Multiply", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Multiply numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("algebra", i),
                i => Assert.Equal("multiply", i));
        }
    }
}
