using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class TangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new TangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Tangent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the tangent of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("tangent", i),
                i => Assert.Equal("tan", i));
        }
    }
}
