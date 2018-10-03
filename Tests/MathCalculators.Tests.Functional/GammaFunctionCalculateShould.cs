using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class GammaFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullyReturnValueGivenAPositiveInteger()
        //{
        //    var function = new GammaFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Argument", phase.Name);
        //    Assert.Equal("Argument for the gamma function.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("z", i.Info.Name);
        //            Assert.Equal("Value to the gamma function.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = 5;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(24, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void SuccessfullyReturnValueGivenAPositiveDouble()
        //{
        //    var function = new GammaFunction();

        //    var phase = function.Calculate();

        //    phase.Inputs[0].Value = 5.5;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(52.342777784553583, TypeConverter.ToObject<double>(i.Value));
        //        });
        //}

        //[Fact]
        //public void SuccessfullyReturnNaNGivenZero()
        //{
        //    var function = new GammaFunction();

        //    var phase = function.Calculate();

        //    phase.Inputs[0].Value = 0;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.True(Double.IsNaN(TypeConverter.ToObject<double>(i.Value)));
        //        });
        //}

        //[Fact]
        //public void FailWhenGivenANegativeInteger()
        //{
        //    var function = new GammaFunction();

        //    var phase = function.Calculate();

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        phase.Inputs[0].Value = -5;
        //    });
        //}
    }
}
