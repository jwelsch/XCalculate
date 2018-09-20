﻿using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class SubtractFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullySubtractNumbers()
        {
            var function = new SubtractFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 3, 2, 1 };

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(0, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailToSubtractASingleNumber()
        {
            var function = new SubtractFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = new int[] { 3 };

                    return p.Inputs;
                });
            });
        }
    }
}
