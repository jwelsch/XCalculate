﻿using System;
using Xunit;

namespace XCalculateLib.Unit
{
    public class AgnosticValueConstructorShould
    {
        [Fact]
        public void SuccesfullyCreateObjectWithMinimalArguments()
        {
            var defaultValue = 123;

            var value = new AgnosticValue(defaultValue);

            Assert.NotNull(value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(defaultValue.GetType(), value.ValueType);
        }

        [Fact]
        public void SuccesfullyCreateObjectWithAllArguments()
        {
            var defaultValue = 123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(object i) => (int)i >= 0 && (int)i < 200;

            var value = new AgnosticValue(defaultValue, new ValueInfo(name, description, unitName), validator);

            Assert.NotNull(value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(defaultValue.GetType(), value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void FailToCreateObjectWithInvalidValue()
        {
            var defaultValue = 123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            bool validator(object i) => (int)i >= 0 && (int)i < 100;

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new AgnosticValue(defaultValue, new ValueInfo(name, description, unitName), validator);
            });
        }

        [Fact]
        public void FailToCreateObjectWithArrayType()
        {
            var defaultValue = new int[] { 1, 2, 3 };

            Assert.Throws<ArgumentException>(() =>
            {
                var value = new AgnosticValue(defaultValue);
            });
        }
    }
}
