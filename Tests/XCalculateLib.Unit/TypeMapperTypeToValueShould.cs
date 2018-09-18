using System;
using Xunit;

namespace XCalculateLib.Unit
{
    public class TypeMapperTypeToValueShould
    {
        [Fact]
        public void SuccessfullyMapByte()
        {
            var value = TypeMapper.TypeToValue(typeof(byte));

            Assert.NotNull(value as ByteValue);
        }

        [Fact]
        public void SuccessfullyMapByteWithArguments()
        {
            var type = typeof(byte);
            var defaultValue = (byte)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<byte>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as ByteValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapSByte()
        {
            var value = TypeMapper.TypeToValue(typeof(sbyte));

            Assert.NotNull(value as SByteValue);
            Assert.Equal(0, (sbyte)value.Value);
        }

        [Fact]
        public void SuccessfullyMapSByteWithArguments()
        {
            var type = typeof(sbyte);
            var defaultValue = (sbyte)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<sbyte>(i => i > 0 && i < 127);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as SByteValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapInt16()
        {
            var value = TypeMapper.TypeToValue(typeof(short));

            Assert.NotNull(value as Int16Value);
            Assert.Equal(0, (short)value.Value);
        }

        [Fact]
        public void SuccessfullyMapInt16WithArguments()
        {
            var type = typeof(short);
            var defaultValue = (short)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<short>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as Int16Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapUInt16()
        {
            var value = TypeMapper.TypeToValue(typeof(ushort));

            Assert.NotNull(value as UInt16Value);
            Assert.Equal(0, (ushort)value.Value);
        }

        [Fact]
        public void SuccessfullyMapUInt16WithArguments()
        {
            var type = typeof(ushort);
            var defaultValue = (ushort)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<ushort>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as UInt16Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapInt32()
        {
            var value = TypeMapper.TypeToValue(typeof(int));

            Assert.NotNull(value as Int32Value);
            Assert.Equal(0, (int)value.Value);
        }

        [Fact]
        public void SuccessfullyMapInt32WithArguments()
        {
            var type = typeof(int);
            var defaultValue = 123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<int>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as Int32Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapUInt32()
        {
            var value = TypeMapper.TypeToValue(typeof(uint));

            Assert.NotNull(value as UInt32Value);
            Assert.Equal<uint>(0, (uint)value.Value);
        }

        [Fact]
        public void SuccessfullyMapUInt32WithArguments()
        {
            var type = typeof(uint);
            var defaultValue = (uint)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<uint>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as UInt32Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapInt64()
        {
            var value = TypeMapper.TypeToValue(typeof(long));

            Assert.NotNull(value as Int64Value);
            Assert.Equal(0, (long)value.Value);
        }

        [Fact]
        public void SuccessfullyMapInt64WithArguments()
        {
            var type = typeof(long);
            var defaultValue = (long)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<long>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as Int64Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapUInt64()
        {
            var value = TypeMapper.TypeToValue(typeof(ulong));

            Assert.NotNull(value as UInt64Value);
            Assert.Equal<ulong>(0, (ulong)value.Value);
        }

        [Fact]
        public void SuccessfullyMapUInt64WithArguments()
        {
            var type = typeof(ulong);
            var defaultValue = (ulong)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<ulong>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as UInt64Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapSingle()
        {
            var value = TypeMapper.TypeToValue(typeof(float));

            Assert.NotNull(value as SingleValue);
            Assert.Equal(0, (float)value.Value);
        }

        [Fact]
        public void SuccessfullyMapSingleWithArguments()
        {
            var type = typeof(float);
            var defaultValue = (float)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<float>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as SingleValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapDouble()
        {
            var value = TypeMapper.TypeToValue(typeof(double));

            Assert.NotNull(value as DoubleValue);
            Assert.Equal(0, (double)value.Value);
        }

        [Fact]
        public void SuccessfullyMapDoubleWithArguments()
        {
            var type = typeof(double);
            var defaultValue = (double)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<double>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as DoubleValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapDecimal()
        {
            var value = TypeMapper.TypeToValue(typeof(decimal));

            Assert.NotNull(value as DecimalValue);
            Assert.Equal(0, (decimal)value.Value);
        }

        [Fact]
        public void SuccessfullyMapDecimalWithArguments()
        {
            var type = typeof(decimal);
            var defaultValue = (decimal)123;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<decimal>(i => i > 0 && i < 200);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as DecimalValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapBoolean()
        {
            var value = TypeMapper.TypeToValue(typeof(bool));

            Assert.NotNull(value as BooleanValue);
            Assert.False((bool)value.Value);
        }

        [Fact]
        public void SuccessfullyMapBooleanWithArguments()
        {
            var type = typeof(bool);
            var defaultValue = true;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<bool>(i => i);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as BooleanValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapString()
        {
            var value = TypeMapper.TypeToValue(typeof(string));

            Assert.NotNull(value as StringValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapStringWithArguments()
        {
            var type = typeof(string);
            var defaultValue = "hello world";
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<string>(i => i.Length > 0 && i.Length < 64);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as StringValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }

        [Fact]
        public void SuccessfullyMapDateTime()
        {
            var value = TypeMapper.TypeToValue(typeof(DateTime));

            Assert.NotNull(value as DateTimeValue);
            Assert.Equal(DateTime.MinValue, (DateTime)value.Value);
        }

        [Fact]
        public void SuccessfullyMapDateTimeWithArguments()
        {
            var type = typeof(DateTime);
            var defaultValue = DateTime.Now;
            var name = "foobar";
            var description = "foobar description";
            var unitName = "foobar unit name";
            var validator = new ValueValidator<DateTime>(i => i > DateTime.MinValue && i <= DateTime.Now);

            var value = TypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unitName), validator });

            Assert.NotNull(value as DateTimeValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unitName, value.Info.UnitName);
        }
    }
}
