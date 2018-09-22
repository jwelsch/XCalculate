using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class AddFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new AddFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Add", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Add numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("add", i));
        }
    }
}
