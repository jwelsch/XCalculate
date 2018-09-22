using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicSecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicSecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Secant", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic secant of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("secant", i),
                i => Assert.Equal("sech", i));
        }
    }
}
