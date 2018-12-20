using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArcsineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArcsineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arcsine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the arcsine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arcsine", i),
                i => Assert.Equal("arcsin", i));
        }
    }
}
