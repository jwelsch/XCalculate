using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArccotangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArccotangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arccotangent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the arccotangent of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arccotangent", i),
                i => Assert.Equal("arccot", i));
        }
    }
}
