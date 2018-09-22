using MathCalculators;
using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArccosecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArccosecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arccosecant", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the arccosecant of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arccosecant", i),
                i => Assert.Equal("arccsc", i));
        }
    }
}
