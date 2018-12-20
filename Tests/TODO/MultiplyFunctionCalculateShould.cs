using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class MultiplyFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullyMultiplyNumbers()
        //{
        //    var function = new MultiplyFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Operands", phase.Name);
        //    Assert.Equal("Specify numbers to multiply.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("Operands", i.Info.Name);
        //            Assert.Equal("Operands to multiply.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = new int[] { 100, 2, 3 };

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(600, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void FailToMultiplyASingleNumber()
        //{
        //    var function = new AddFunction();

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        var phase = function.Calculate();

        //        Assert.NotNull(phase);

        //        phase.Inputs[0].Value = new int[] { 1 };
        //    });
        //}
    }
}
