using System;
using Xunit;

namespace DateTimeCalculators.Tests.Functional
{
    public class AddDaysFunctionConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new AddDaysFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("Add Days", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Calculates the date that is a number of days from a certain date.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("date", i),
                i => Assert.Equal("add", i),
                i => Assert.Equal("day", i));
        }
    }
}
