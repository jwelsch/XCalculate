using System;
using System.Linq;
using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class ArrayValueValueShould
    {
        [Fact]
        public void SuccessfullySetNewValueOfSameType()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var newValue = new int[] { 4, 5, 6, 7 };

            var value = new ArrayValue<int[]>(defaultValue);

            value.Value = newValue;

            Assert.Collection(value.Value,
                i => Assert.Equal(newValue[0], i),
                i => Assert.Equal(newValue[1], i),
                i => Assert.Equal(newValue[2], i),
                i => Assert.Equal(newValue[3], i));
            Assert.Equal(newValue.GetType(), value.Value.GetType());
        }

        [Fact]
        public void FailToSetNewValueWithDifferentType()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var newValue = new double[] { 4.0, 5.0, 6.0, 7.0 };

            var value = new ArrayValue<int[]>(defaultValue);

            Assert.Throws<ArgumentException>(() =>
            {
                ((IValue)value).Value = newValue;
            });
        }

        [Fact]
        public void FailToSetNewValueThatIsInvalid()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var newValue = new int[] { 4, 5, 6, 7 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(int[] i) => i.Length >= 0 && i.Length < 10 && i.All(j => j > 0 && j < 5);

            var value = new ArrayValue<int[]>(defaultValue, new ValueInfo(name, description, unit), validator);

            Assert.Throws<ArgumentException>(() =>
            {
                value.Value = newValue;
            });
        }
    }
}
