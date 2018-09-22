using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArctangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArctangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arctangent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the arctangent of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arctangent", i),
                i => Assert.Equal("arctan", i));
        }
    }
}
