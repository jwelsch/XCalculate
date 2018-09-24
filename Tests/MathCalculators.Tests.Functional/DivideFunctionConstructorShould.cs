using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class DivideFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new DivideFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Divide", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Divide numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("divide", i));
        }
    }
}
