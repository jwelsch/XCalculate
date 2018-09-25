﻿using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class MultiplyFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyMultiplyNumbers()
        {
            var function = new MultiplyFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = new int[] { 100, 2, 3 };
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(600, TypeConverter.ToObject<int>(result.Value));
        }

        [Fact]
        public void FailToMultiplyASingleNumber()
        {
            var function = new MultiplyFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(p =>
                {
                    p.Inputs[0].Value = new int[] { 3 };
                });
            });
        }
    }
}
