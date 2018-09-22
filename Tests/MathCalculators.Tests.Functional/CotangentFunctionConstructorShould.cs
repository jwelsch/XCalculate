using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class CotangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new CotangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Cotangent", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the cotangent of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("cotangent", i),
                i => Assert.Equal("cot", i));
        }
    }
}
