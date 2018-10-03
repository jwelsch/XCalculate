using System;
using System.Linq;
using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class ValueTypeMapperTypeToValueShould
    {
        [Fact]
        public void SuccessfullyMapByte()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(byte));

            Assert.NotNull(value as ByteValue);
            Assert.Equal(0, (byte)value.Value);
        }

        [Fact]
        public void SuccessfullyMapByteWithArguments()
        {
            var type = typeof(byte);
            var defaultValue = (byte)123;
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<byte>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as ByteValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapSByte()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(sbyte));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<sbyte>(i => i > 0 && i < 127);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as SByteValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapInt16()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(short));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<short>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as Int16Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapUInt16()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(ushort));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<ushort>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as UInt16Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapInt32()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(int));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<int>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as Int32Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapUInt32()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(uint));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<uint>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as UInt32Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapInt64()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(long));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<long>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as Int64Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapUInt64()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(ulong));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<ulong>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as UInt64Value);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapSingle()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(float));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<float>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as SingleValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapDouble()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(double));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<double>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as DoubleValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapDecimal()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(decimal));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<decimal>(i => i > 0 && i < 200);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as DecimalValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapBoolean()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(bool));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<bool>(i => i);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as BooleanValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapString()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(string));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<string>(i => i.Length > 0 && i.Length < 64);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as StringValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapDateTime()
        {
            var value = ValueTypeMapper.TypeToValue(typeof(DateTime));

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
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var validator = new ValueValidator<DateTime>(i => i > DateTime.MinValue && i <= DateTime.Now);

            var value = ValueTypeMapper.TypeToValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as DateTimeValue);
            Assert.Equal(defaultValue, value.Value);
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapByteArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(byte[]));

            Assert.NotNull(value as ByteArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapByteArrayWithArguments()
        {
            var type = typeof(byte[]);
            var defaultValue = new byte[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<byte[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as ByteArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapSByteArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(sbyte[]));

            Assert.NotNull(value as SByteArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapSByteArrayWithArguments()
        {
            var type = typeof(sbyte[]);
            var defaultValue = new sbyte[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<sbyte[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 127));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as SByteArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapInt16Array()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(short[]));

            Assert.NotNull(value as Int16ArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapInt16ArrayWithArguments()
        {
            var type = typeof(short[]);
            var defaultValue = new short[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<short[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as Int16ArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapUInt16Array()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(ushort[]));

            Assert.NotNull(value as UInt16ArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapUInt16ArrayWithArguments()
        {
            var type = typeof(ushort[]);
            var defaultValue = new ushort[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<ushort[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as UInt16ArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapInt32Array()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(int[]));

            Assert.NotNull(value as Int32ArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapInt32ArrayWithArguments()
        {
            var type = typeof(int[]);
            var defaultValue = new int[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<int[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as Int32ArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapUInt32Array()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(uint[]));

            Assert.NotNull(value as UInt32ArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapUInt32ArrayWithArguments()
        {
            var type = typeof(uint[]);
            var defaultValue = new uint[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<uint[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as UInt32ArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapInt64Array()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(long[]));

            Assert.NotNull(value as Int64ArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapInt64ArrayWithArguments()
        {
            var type = typeof(long[]);
            var defaultValue = new long[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<long[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as Int64ArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapUInt64Array()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(ulong[]));

            Assert.NotNull(value as UInt64ArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapUInt64ArrayWithArguments()
        {
            var type = typeof(ulong[]);
            var defaultValue = new ulong[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<ulong[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as UInt64ArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapSingleArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(float[]));

            Assert.NotNull(value as SingleArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapSingleArrayWithArguments()
        {
            var type = typeof(float[]);
            var defaultValue = new float[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<float[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as SingleArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapDoubleArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(double[]));

            Assert.NotNull(value as DoubleArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapDoubleArrayWithArguments()
        {
            var type = typeof(double[]);
            var defaultValue = new double[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<double[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as DoubleArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapDecimalArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(decimal[]));

            Assert.NotNull(value as DecimalArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapDecimalArrayWithArguments()
        {
            var type = typeof(decimal[]);
            var defaultValue = new decimal[] { 0, 1, 3 };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<decimal[]>(i => i.Length < 64 && i.All(j => j >= 0 && j < 200));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as DecimalArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapBooleanArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(bool[]));

            Assert.NotNull(value as BooleanArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapBooleanArrayWithArguments()
        {
            var type = typeof(bool[]);
            var defaultValue = new bool[] { true, true, true };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<bool[]>(i => i.Length < 64 && i.All(j => j));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as BooleanArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapStringArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(string[]));

            Assert.NotNull(value as StringArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapStringArrayWithArguments()
        {
            var type = typeof(string[]);
            var defaultValue = new string[] { "hello world1", "hello world2", "hello world3" };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<string[]>(i => i.Length > 0 && i.Length < 64);

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as StringArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }

        [Fact]
        public void SuccessfullyMapDateTimeArray()
        {
            var value = ValueTypeMapper.TypeToArrayValue(typeof(DateTime[]));

            Assert.NotNull(value as DateTimeArrayValue);
            Assert.Null(value.Value);
        }

        [Fact]
        public void SuccessfullyMapDateTimeArrayWithArguments()
        {
            var type = typeof(DateTime[]);
            var defaultValue = new DateTime[] { DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2) };
            var name = "foobar";
            var description = "foobar description";
            var unit = new XCalculateLib.Unit("foobar", "foobars", "fb", "fbs");
            var range = new Range(0, 127);
            var validator = new ValueValidator<DateTime[]>(i => i.Length < 64 && i.All(j => j >= DateTime.MinValue && j <= DateTime.Now));

            var value = ValueTypeMapper.TypeToArrayValue(type, () => new object[] { defaultValue, new ValueInfo(name, description, unit), validator });

            Assert.NotNull(value as DateTimeArrayValue);
            Assert.Collection(defaultValue,
                i => Assert.Equal(defaultValue[0], i),
                i => Assert.Equal(defaultValue[1], i),
                i => Assert.Equal(defaultValue[2], i));
            Assert.Equal(type, value.ValueType);
            Assert.NotNull(value.Info);
            Assert.Equal(name, value.Info.Name);
            Assert.Equal(description, value.Info.Description);
            Assert.Equal(unit, value.Info.Unit);
        }
    }
}
