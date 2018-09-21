﻿using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class SubtractFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new SubtractFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Subtract", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Subtract numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("subtract", i));
        }
    }
}
