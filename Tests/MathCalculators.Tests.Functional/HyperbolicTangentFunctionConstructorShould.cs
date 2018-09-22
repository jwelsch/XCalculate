using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicTangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicTangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Tangent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic tangent of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("tangent", i),
                i => Assert.Equal("tanh", i));
        }
    }
}
