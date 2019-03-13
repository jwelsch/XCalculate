using System;
using System.Linq;
using Xunit;

namespace XCalculateLib.Tests.Unit
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
            Assert.Equal(defaultValue.GetType(), value.Value.GetType());
            Assert.True(value.IsArrayValue);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithAllArguments()
        {
            var defaultValue = new int[] { 1, 2, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(int[] i) => i.Length >= 0 && i.Length < 10 && i.All(j => j > 0 && j < 10);

            var value = new ArrayValue<int[]>(defaultValue, new ValueInfo(name, description, unit), validator);

            Assert.NotNull(value);
            Assert.Collection(value.Value,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(defaultValue.GetType(), value.Value.GetType());
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
            Assert.True(value.IsArrayValue);
        }

        [Fact]
        public void FailWhenValueIsInvalid()
        {
            var defaultValue = new int[] { 1, 2, 30 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            bool validator(int[] i) => i.Length >= 0 && i.Length < 10 && i.All(j => j > 0 && j < 10);

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new ArrayValue<int[]>(defaultValue, new ValueInfo(name, description, unit), validator);
            });
        }

        //[Fact]
        //public void FailWhenTypeIsNotAnArray()
        //{
        //    var defaultValue = 123;
        //    var name = "foobar";
        //    var description = "foobar description";
        //    var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
        //    bool validator(int i) => i >= 0 && i < 100;

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        var value = new ArrayValue<int>(defaultValue, new ValueInfo(name, description, unit), validator);
        //    });
        //}
    }
}
