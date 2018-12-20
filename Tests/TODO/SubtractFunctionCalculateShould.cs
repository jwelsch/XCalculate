using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class SubtractFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullySubtractNumbers()
        //{
        //    var function = new SubtractFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Operands", phase.Name);
        //    Assert.Equal("Specify numbers to subtract.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("Operands", i.Info.Name);
        //            Assert.Equal("Operands to subtract.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = new int[] { 3, 2, 1 };

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void FailToSubtractASingleNumber()
        //{
        //    var function = new SubtractFunction();

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        var phase = function.Calculate();

        //        Assert.NotNull(phase);

        //        phase.Inputs[0].Value = new int[] { 1 };
        //    });
        //}
    }
}
