using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ExponentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ExponentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Exponent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Raise a number to a power.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arithmetic", i),
                i => Assert.Equal("exponent", i),
                i => Assert.Equal("power", i));
        }
    }
}
