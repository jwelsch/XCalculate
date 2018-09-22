using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class NaturalLogarithmFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new NaturalLogarithmFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Natural Logarithm", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the natural logarithm of a number.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("natural", i),
                i => Assert.Equal("logarithm", i),
                i => Assert.Equal("e", i));
        }
    }
}
