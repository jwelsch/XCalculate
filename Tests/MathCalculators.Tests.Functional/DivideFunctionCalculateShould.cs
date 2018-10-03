using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class DivideFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullyDivideNumbers()
        //{
        //    var function = new DivideFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Operands", phase.Name);
        //    Assert.Equal("Specify numbers to divide.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("Operands", i.Info.Name);
        //            Assert.Equal("Operands to divide.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = new int[] { 100, 2, 2 };

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(25, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void FailToDivideASingleNumber()
        //{
        //    var function = new DivideFunction();

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        var phase = function.Calculate();

        //        Assert.NotNull(phase);

        //        phase.Inputs[0].Value = new int[] { 1 };
        //    });
        //}

        //[Fact]
        //public void FailToDivideByZero()
        //{
        //    var function = new DivideFunction();

        //    Assert.Throws<DivideByZeroException>(() =>
        //    {
        //        var phase = function.Calculate();

        //        Assert.NotNull(phase);

        //        phase.Inputs[0].Value = new int[] { 2, 0 };
        //    });
        //}
    }
}
