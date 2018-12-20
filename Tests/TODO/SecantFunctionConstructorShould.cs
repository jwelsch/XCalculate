using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class SecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new SecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Secant", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the secant of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("secant", i),
                i => Assert.Equal("sec", i));
        }
    }
}
