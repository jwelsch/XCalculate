using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class FactorialFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullyReturnValueGivenAPositiveInteger()
        //{
        //    var function = new FactorialFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Argument", phase.Name);
        //    Assert.Equal("Argument for the factorial function.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("n", i.Info.Name);
        //            Assert.Equal("Value to the factorial function.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = 5;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(120, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void SuccessfullyReturnValueGivenAPositiveDouble()
        //{
        //    var function = new FactorialFunction();

        //    var phase = function.Calculate();

        //    phase.Inputs[0].Value = 5.5;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(287.88527781504507, TypeConverter.ToObject<double>(i.Value));
        //        });
        //}

        //[Fact]
        //public void SuccessfullyReturnOneGivenZero()
        //{
        //    var function = new FactorialFunction();

        //    var phase = function.Calculate();

        //    phase.Inputs[0].Value = 0;

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(1, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void FailWhenGivenANegativeInteger()
        //{
        //    var function = new FactorialFunction();

        //    var phase = function.Calculate();

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        phase.Inputs[0].Value = -5;
        //    });
        //}
    }
}
