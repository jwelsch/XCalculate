using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ModuloFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ModuloFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Modulo", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the C# standard remainder of two numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("algebra", i),
                i => Assert.Equal("modulo", i),
                i => Assert.Equal("remainder", i));
        }
    }
}
