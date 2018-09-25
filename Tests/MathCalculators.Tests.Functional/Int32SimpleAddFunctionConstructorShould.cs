using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class Int32SimpleAddFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new Int32SimpleAddFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Simple Add", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Add numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("add", i));
        }
    }
}
