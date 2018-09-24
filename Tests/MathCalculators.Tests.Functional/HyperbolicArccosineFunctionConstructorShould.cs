using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArccosineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicArccosineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Arccosine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic arccosine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("arccosine", i),
                i => Assert.Equal("arccosh", i));
        }
    }
}
