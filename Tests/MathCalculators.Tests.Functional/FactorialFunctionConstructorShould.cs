using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class FactorialFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new FactorialFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Factorial", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Apply the factorial function to a number.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("factorial", i));
        }
    }
}
