using System;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class Int32SimpleAddFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyAddNumbers()
        {
            var function = new Int32SimpleAddFunction();

            var result = function.Calculate(1, 2, 3);

            Assert.Equal(6, result);
        }

        [Fact]
        public void FailWhenGivenOneNumber()
        {
            var function = new Int32SimpleAddFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate(3);
            });
        }

        [Fact]
        public void FailWhenGivenZeroNumbers()
        {
            var function = new Int32SimpleAddFunction();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = function.Calculate();
            });
        }

        [Fact]
        public void FailWhenGivenNull()
        {
            var function = new Int32SimpleAddFunction();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = function.Calculate((int[])null);
            });
        }
    }
}
