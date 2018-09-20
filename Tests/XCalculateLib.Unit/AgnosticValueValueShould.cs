using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XCalculateLib.Unit
{
    public class AgnosticValueValueShould
    {
        [Fact]
        public void SuccessfullySetNewValueOfSameType()
        {
            var defaultValue = 123;
            var newValue = 321;

            var value = new AgnosticValue(defaultValue);

            value.Value = newValue;

            Assert.Equal(newValue, value.Value);
            Assert.Equal(newValue.GetType(), value.ValueType);
        }

        [Fact]
        public void SuccessfullySetNewValueWithDifferentType()
        {
            var defaultValue = 123;
            var newValue = 321.0;

            var value = new AgnosticValue(defaultValue);

            value.Value = newValue;

            Assert.Equal(newValue, value.Value);
            Assert.Equal(newValue.GetType(), value.ValueType);
        }

        [Fact]
        public void FailToSetNewValueThatIsInvalid()
        {
            var defaultValue = 123;
            var newValue = 321.0;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(object i) => TypeConverter.ToObject<int>(i) > 0 && TypeConverter.ToObject<int>(i) < 200;

            var value = new AgnosticValue(defaultValue, new ValueInfo(name, description, unitName), validator);

            Assert.Throws<ArgumentException>(() =>
            {
                value.Value = newValue;
            });
        }

        [Fact]
        public void FailToSetNewValueThatIsAnArrayType()
        {
            var defaultValue = 123;
            var newValue = new int[] { 4, 5, 6, 7 };

            var value = new AgnosticValue(defaultValue);

            Assert.Throws<ArgumentException>(() =>
            {
                value.Value = newValue;
            });
        }
    }
}
