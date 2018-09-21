using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class GammaFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new GammaFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Gamma", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Apply the gamma function to a number.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("gamma", i));
        }
    }
}
