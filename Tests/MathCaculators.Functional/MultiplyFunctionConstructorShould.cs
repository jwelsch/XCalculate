﻿using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class MultiplyFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new MultiplyFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Multiply", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Multiply numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("multiply", i));
        }
    }
}
