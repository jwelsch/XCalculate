using System;
using XCalculateLib;
using Xunit;

namespace DateTimeCalculators.Tests.Functional
{
    public class AddDaysFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyReturnWithDefaultValues()
        {
            var function = new AddDaysFunction();

            var inputs = function.GetInputs();

            Assert.Equal(2, inputs.Length);

            var result = function.Calculate(inputs);

            Assert.Collection(result,
                i =>
                {
                    Assert.Equal(typeof(double), i.Value.GetType());
                    Assert.Equal(Math.IEEERemainder(0.0, 1.0), TypeConverter.ToObject<double>(i.Value));
                });
        }
    }
}
