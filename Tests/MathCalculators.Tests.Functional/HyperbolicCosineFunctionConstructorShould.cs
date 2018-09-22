using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicCosineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicCosineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Cosine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic cosine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("cosine", i),
                i => Assert.Equal("cosh", i));
        }
    }
}
