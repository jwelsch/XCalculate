﻿using MathCalculators;
using Xunit;

namespace MathCaculators.Functional
{
    public class TangentFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new TangentFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Tangent", function.FunctionInfo.Name);
            Assert.NotEqual(string.Empty, function.FunctionInfo.Description);
            Assert.NotEmpty(function.FunctionInfo.Tags);
            Assert.Equal(2, function.FunctionInfo.Tags.Length);
            Assert.NotNull(function.FunctionInfo.Version);
        }
    }
}