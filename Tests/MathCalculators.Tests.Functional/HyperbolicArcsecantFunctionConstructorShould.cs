using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArcsecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new HyperbolicArcsecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Hyperbolic Arcsecant", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the hyperbolic arcsecant of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("hyperbolic", i),
                i => Assert.Equal("arcsecant", i),
                i => Assert.Equal("arcsech", i));
        }
    }
}
