using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class CosecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new CosecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Cosecant", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the cosecant of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("cosecant", i),
                i => Assert.Equal("csc", i));
        }
    }
}
