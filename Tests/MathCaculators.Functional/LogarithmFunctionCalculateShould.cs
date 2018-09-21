﻿using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class LogarithmFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateAnLogarithm()
        {
            var function = new LogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8;
                p.Inputs[1].Value = 3;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Log(8, 3), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateAnLogarithmWithOnlyBaseSpecified()
        {
            var function = new LogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 8;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Log(8, 10), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateAnLogarithmWithOnlyLogarithmSpecified()
        {
            var function = new LogarithmFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[1].Value = 3;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Log(0, 3), TypeConverter.ToObject<double>(result.Value));
        }
    }
}