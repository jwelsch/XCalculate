using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class ArcsecantFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArcsecantFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arcsecant", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the arcsecant of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arcsecant", i),
                i => Assert.Equal("arcsec", i));
        }
    }
}
