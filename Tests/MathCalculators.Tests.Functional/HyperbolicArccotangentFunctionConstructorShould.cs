using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArccotangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicArccotangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Arccotangent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic arccotangent of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("arccotangent", i),
                i => Assert.Equal("arccoth", i));
        }
    }
}
