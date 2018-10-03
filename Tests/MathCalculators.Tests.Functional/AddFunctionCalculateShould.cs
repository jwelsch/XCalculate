using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class AddFunctionCalculateShould
    {
        //[Fact]
        //public void SuccessfullyAddNumbers()
        //{
        //    var function = new AddFunction();

        //    var phase = function.Calculate();

        //    Assert.NotNull(phase);
        //    Assert.Equal("Specify Operands", phase.Name);
        //    Assert.Equal("Specify numbers to add.", phase.Description);
        //    Assert.Collection(phase.Inputs,
        //        i =>
        //        {
        //            Assert.Equal("Operands", i.Info.Name);
        //            Assert.Equal("Operands to add.", i.Info.Description);
        //            Assert.Null(i.Info.Unit);
        //        });

        //    phase.Inputs[0].Value = new int[] { 1, 2, 3 };

        //    Assert.Null(function.Calculate(phase));

        //    Assert.Collection(function.CurrentResult,
        //        i =>
        //        {
        //            Assert.Equal(typeof(double), i.ValueType);
        //            Assert.Equal(6, TypeConverter.ToObject<int>(i.Value));
        //        });
        //}

        //[Fact]
        //public void FailToAddASingleNumber()
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
