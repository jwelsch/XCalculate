using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class RootFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new RootFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Root", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the root of a number.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("root", i));
        }
    }
}
