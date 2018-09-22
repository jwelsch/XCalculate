using System;
using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class AgnosticArrayValueConstructorShould
    {
        [Fact]
        public void SuccesfullyCreateObjectWithMinimalArguments()
        {
            var defaultValue = new int[] { 1, 2, 3 };

            var value = new AgnosticArrayValue(defaultValue);

            Assert.NotNull(value);
            Assert.Collection((int[])value.Value,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.ValueType);
        }

        [Fact]
        public void SuccesfullyCreateObjectWithAllArguments()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(object i) => ((int[])i).Length >= 0 && ((int[])i).Length < 200;

            var value = new AgnosticArrayValue(defaultValue, new ValueInfo(name, description, unit), validator);

            Assert.NotNull(value);
            Assert.Collection((int[])value.Value,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithNullValue()
        {
            Array defaultValue = null;
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(object i) => true;

            var value = new AgnosticArrayValue(defaultValue, new ValueInfo(name, description, unit), validator);

            Assert.NotNull(value);
            Assert.Null(value.Value);
            Assert.Null(value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void FailToCreateObjectWithInvalidValue()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(object i) => ((int[])i).Length >= 0 && ((int[])i).Length < 3;

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new AgnosticArrayValue(defaultValue, new ValueInfo(name, description, unit), validator);
            });
        }
    }
}
