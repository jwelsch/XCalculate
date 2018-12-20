using System;
using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class ValueConstructorShould
    {
        [Fact]
        public void SuccessfullyCreateObjectWithOnlyValueArgument()
        {
            var defaultValue = 123;

            var value = new Value<int>(defaultValue);

            Assert.NotNull(value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(defaultValue.GetType(), value.ValueType);
            Assert.False(value.IsArrayValue);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithAllArguments()
        {
            var defaultValue = 123;
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(int i) => i >= 0 && i < 200;

            var value = new Value<int>(defaultValue, new ValueInfo(name, description, unit), validator);

            Assert.NotNull(value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(defaultValue.GetType(), value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
            Assert.False(value.IsArrayValue);
        }

        [Fact]
        public void FailWhenValueIsInvalid()
        {
            var defaultValue = 123;
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(int i) => i >= 0 && i < 100;

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new Value<int>(defaultValue, new ValueInfo(name, description, unit), validator);
            });
        }
    }
}
