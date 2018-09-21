﻿using MathCalculators;
using System;
using Xunit;

namespace MathCaculators.Functional
{
    public class ArccosineFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new ArccosineFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Arccosine", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the arccosine of an angle.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("arccosine", i),
                i => Assert.Equal("arccos", i));
        }
    }
}
