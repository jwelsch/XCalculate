using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicSineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicSineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Sine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic sine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("sine", i),
                i => Assert.Equal("sinh", i));
        }
    }
}
