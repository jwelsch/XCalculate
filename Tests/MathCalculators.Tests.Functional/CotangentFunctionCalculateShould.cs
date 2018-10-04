﻿using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class CotangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateCotangentOfPositiveAngle()
        {
            var value = 60;
            var function = new CotangentFunction();

            var phase = function.Calculate();

            Assert.NotNull(phase);
            Assert.Equal("Specify Argument", phase.Name);
            Assert.Equal("Specify angle to find the cotangent of.", phase.Description);
            Assert.Collection(phase.Inputs,
                i =>
                {
                    Assert.Equal("Angle", i.Info.Name);
                    Assert.Null(i.Info.Description);
                    Assert.Equal(new RadianUnit(), i.Info.Unit);
                });

            phase.Inputs[0].Value = value;

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(1.0 / Math.Tan(value), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateCotangentOfNegativeAngle()
        {
            var value = -54;
            var function = new CotangentFunction();

            var phase = function.Calculate();

            Assert.NotNull(phase);

            phase.Inputs[0].Value = value;

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), i.ValueType);
                    Assert.Equal(1.0 / Math.Tan(value), TypeConverter.ToObject<double>(i.Value));
                });
        }

        [Fact]
        public void SuccessfullyCalculateCotangentWithNoAngleSpecified()
        {
            var function = new CotangentFunction();

            var phase = function.Calculate();

            Assert.NotNull(phase);

            Assert.Null(function.Calculate(phase));

            Assert.Collection(function.CurrentResult,
                i =>
                {
                    Assert.Equal(typeof(double), function.CurrentResult[0].ValueType);
                    Assert.Equal(1.0 / Math.Tan(0.0), TypeConverter.ToObject<double>(function.CurrentResult[0].Value));
                });
        }
    }
}
