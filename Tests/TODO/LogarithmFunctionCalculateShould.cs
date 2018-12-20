using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class LogarithmFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullyCalculateALogarithm()
        //{
        //    var function = new LogarithmFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Arguments", phase.Name);
        //    Assert.Equal("Specify logarithm arguments.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("Argument", i.Info.Name);
        //            Assert.Equal("Argument of the logarithm.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        },
        //        i =>
        //        {
        //            Assert.Equal("Base", i.Info.Name);
        //            Assert.Equal("Base of the logarithm.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = 8;
        //    phase.Inputs[1].Value = 3;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(Math.Log(8, 3), TypeConverter.ToObject<double>(i.Value));
        //        });
        //}

        //[Fact]
        //public void SuccessfullyCalculateALogarithmWithOnlyBaseSpecified()
        //{
        //    var function = new LogarithmFunction();

        //    var phase = function.Calculate();

        //    phase.Inputs[1].Value = 3;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(Math.Log(0, 3), TypeConverter.ToObject<double>(i.Value));
        //        });
        //}

        //[Fact]
        //public void SuccessfullyCalculateALogarithmWithOnlyLogarithmSpecified()
        //{
        //    var function = new LogarithmFunction();

        //    var phase = function.Calculate();

        //    phase.Inputs[0].Value = 8;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(Math.Log(8, 10), TypeConverter.ToObject<double>(i.Value));
        //        });
        //}
    }
}
