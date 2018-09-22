using System;
using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class AgnosticArrayValueValueShould
    {
        [Fact]
        public void SuccessfullySetNewValueOfSameType()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var newValue = new int[] { 4, 5, 6, 7 };

            var value = new AgnosticArrayValue(defaultValue);

            value.Value = newValue;

            Assert.Collection((int[])value.Value,
                i => Assert.Equal(newValue[0], i),
                i => Assert.Equal(newValue[1], i),
                i => Assert.Equal(newValue[2], i),
                i => Assert.Equal(newValue[3], i));
            Assert.Equal(newValue.GetType(), value.ValueType);
        }

        [Fact]
        public void SuccessfullySetNewValueWithDifferentType()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var newValue = new double[] { 4.0, 5.0, 6.0, 7.0 };

            var value = new AgnosticArrayValue(defaultValue);

            value.Value = newValue;

            Assert.Collection((double[])value.Value,
                i => Assert.Equal(newValue[0], i),
                i => Assert.Equal(newValue[1], i),
                i => Assert.Equal(newValue[2], i),
                i => Assert.Equal(newValue[3], i));
            Assert.Equal(newValue.GetType(), value.ValueType);
        }

        [Fact]
        public void FailToSetNewValueThatIsInvalid()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var newValue = new int[] { 4, 5, 6, 7 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(Array i)
            {
                return i.Length > 0 && i.Length <= 3;
            }

            var value = new AgnosticArrayValue(defaultValue, new ValueInfo(name, description, unit), validator);

            Assert.Throws<ArgumentException>(() =>
            {
                value.Value = newValue;
            });
        }
    }
}
