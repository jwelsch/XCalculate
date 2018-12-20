using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArcsineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicArcsineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Arcsine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic arcsine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("arcsine", i),
                i => Assert.Equal("arcsinh", i));
        }
    }
}
