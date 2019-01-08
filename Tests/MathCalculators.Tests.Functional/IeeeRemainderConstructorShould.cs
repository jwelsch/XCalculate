using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class IeeeRemainderConstructorShould
    {
        [Fact]
        public void SuccessfullySetFunctionInfo()
        {
            var function = new IeeeRemainderFunction();

            Assert.NotNull(function.FunctionInfo);
            Assert.Equal("IEEE Remainder", function.FunctionInfo.Name);
            Assert.Equal(new Version("1.0.0"), function.FunctionInfo.Version);
            Assert.Equal("Find the IEEE 754 conformant remainder of two numbers.", function.FunctionInfo.Description);
            Assert.Collection(function.FunctionInfo.Tags,
                i => Assert.Equal("algebra", i),
                i => Assert.Equal("remainder", i));
        }
    }
}
