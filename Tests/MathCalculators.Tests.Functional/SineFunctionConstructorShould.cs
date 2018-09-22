using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class SineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new SineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Sine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the sine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("sine", i),
                i => Assert.Equal("sin", i));
        }
    }
}
