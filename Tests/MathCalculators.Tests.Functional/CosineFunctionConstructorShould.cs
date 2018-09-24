using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class CosineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new CosineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Cosine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the cosine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("cosine", i),
                i => Assert.Equal("cos", i));
        }
    }
}
