using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ExponentFunctionCalculateShould
    {
       // [Fact]
       // public void SuccessfullyCalculateAnExponent()
       // {
       //     var function = new ExponentFunction();

       //     var phase = function.Calculate();

       //     Assert.NotNull(phase);
       //     Assert.Equal("Specify Operands", phase.Name);
       //     Assert.Equal("Specify exponential equation values.", phase.Description);
       //     Assert.Collection(phase.Inputs,
       //         i =>
       //         {
       //             Assert.Equal("Base", i.Info.Name);
       //             Assert.Null(i.Info.Description);
       //             Assert.Null(i.Info.Unit);
       //         },
       //         i =>
       //         {
       //             Assert.Equal("Exponent", i.Info.Name);
       //             Assert.Null(i.Info.Description);
       //             Assert.Null(i.Info.Unit);
       //         });

       //     phase.Inputs[0].Value = 8;
       //     phase.Inputs[1].Value = 3;

       //     Assert.Null(function.Calculate(phase));

       //     Assert.Collection(function.CurrentResult,
       //         i =>
       //         {
       //             Assert.Equal(typeof(double), i.ValueType);
       //             Assert.Equal(512, TypeConverter.ToObject<int>(i.Value));
       //         });
       //}

       // [Fact]
       // public void SuccessfullyCalculateAnExponentWithOnlyBaseSpecified()
       // {
       //     var function = new ExponentFunction();

       //     var phase = function.Calculate();

       //     Assert.NotNull(phase);

       //     phase.Inputs[0].Value = 8;

       //     Assert.Null(function.Calculate(phase));

       //     Assert.Collection(function.CurrentResult,
       //         i =>
       //         {
       //             Assert.Equal(typeof(double), i.ValueType);
       //             Assert.Equal(1, TypeConverter.ToObject<int>(i.Value));
       //         });
       // }

       // [Fact]
       // public void SuccessfullyCalculateAnExponentWithOnlyExponentSpecified()
       // {
       //     var function = new ExponentFunction();
       //     var phase = function.Calculate();

       //     Assert.NotNull(phase);

       //     phase.Inputs[1].Value = 3;

       //     Assert.Null(function.Calculate(phase));

       //     Assert.Collection(function.CurrentResult,
       //         i =>
       //         {
       //             Assert.Equal(typeof(double), i.ValueType);
       //             Assert.Equal(0, TypeConverter.ToObject<int>(i.Value));
       //         });
       // }
    }
}
