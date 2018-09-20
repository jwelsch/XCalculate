using System;
using System.Linq;
using Xunit;

namespace XCalculateLib.Unit
{
    public class ArrayValueConstructorShould
    {
        [Fact]
        public void SuccessfullyCreateObjectWithOnlyValueArgument()
        {
            var defaultValue = new int[] { 1, 2, 3 };

            var value = new ArrayValue<int[]>(defaultValue);

            Assert.NotNull(value);
            Assert.Collection(value.Value,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.ValueType);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithAllArguments()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(int[] i) => i.Length >= 0 && i.Length < 10 && i.All(j => j > 0 && j < 10);

            var value = new ArrayValue<int[]>(defaultValue, new ValueInfo(name, description, unitName), validator);

            Assert.NotNull(value);
            Assert.Collection(value.Value,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void FailWhenValueIsInvalid()
        {
            var defaultValue = new int[] { 1, 2, 30 };
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(int[] i) => i.Length >= 0 && i.Length < 10 && i.All(j => j > 0 && j < 10);

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new ArrayValue<int[]>(defaultValue, new ValueInfo(name, description, unitName), validator);
            });
        }

        [Fact]
        public void FailWhenTypeIsNotAnArray()
        {
            var defaultValue = 123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(int i) => i >= 0 && i < 100;

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new ArrayValue<int>(defaultValue, new ValueInfo(name, description, unitName), validator);
            });
        }
    }
}
