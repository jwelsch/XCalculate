using System;
using Xunit;

namespace XCalculateLib.Unit
{
    public class ValueValueShould
    {
        [Fact]
        public void SuccessfullySetNewValueOfSameType()
        {
            var defaultValue = 123;
            var newValue = 321;

            var value = new Value<int>(defaultValue);

            value.Value = newValue;

            Assert.Equal(newValue, value.Value);
            Assert.Equal(newValue.GetType(), value.ValueType);
        }

        [Fact]
        public void FailToSetNewValueWithDifferentType()
        {
            var defaultValue = 123;
            var newValue = 321.0;

            var value = new Value<int>(defaultValue);

            Assert.Throws<ArgumentException>(() =>
            {
                ((IValue)value).Value = newValue;
            });
        }

        [Fact]
        public void FailToSetNewValueThatIsInvalid()
        {
            var defaultValue = 123;
            var newValue = 321;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(int i) => i >= 0 && i < 200;

            var value = new Value<int>(defaultValue, new ValueInfo(name, description, unitName), validator);

            Assert.Throws<ArgumentException>(() =>
            {
                value.Value = newValue;
            });
        }
    }
}
