using System;
using System.Collections.Generic;

namespace XCalculateLib
{
    public static class TypeMapper
    {
        private class MapTypes
        {
            public Type SingleValue
            {
                get;
                private set;
            }

            public Type ArrayValue
            {
                get;
                private set;
            }

            public Func<Type, object> Activator
            {
                get;
                private set;
            }

            public MapTypes(Type singleValue, Type arrayValue, Func<Type, object> activator)
            {
                this.SingleValue = singleValue;
                this.ArrayValue = arrayValue;
                this.Activator = activator;
            }
        }

        private static Dictionary<Type, MapTypes> Map = new Dictionary<Type, MapTypes>();

        static TypeMapper()
        {
            object objectActivator(Type t) => Activator.CreateInstance(t);

            Map.Add(typeof(sbyte), new MapTypes(typeof(SByteValue), typeof(SByteArrayValue), objectActivator));
            Map.Add(typeof(byte), new MapTypes(typeof(ByteValue), typeof(ByteArrayValue), objectActivator));
            Map.Add(typeof(short), new MapTypes(typeof(Int16Value), typeof(Int16ArrayValue), objectActivator));
            Map.Add(typeof(ushort), new MapTypes(typeof(UInt16Value), typeof(UInt16ArrayValue), objectActivator));
            Map.Add(typeof(int), new MapTypes(typeof(Int32Value), typeof(Int32ArrayValue), objectActivator));
            Map.Add(typeof(uint), new MapTypes(typeof(UInt32Value), typeof(UInt32ArrayValue), objectActivator));
            Map.Add(typeof(long), new MapTypes(typeof(Int64Value), typeof(Int64ArrayValue), objectActivator));
            Map.Add(typeof(ulong), new MapTypes(typeof(UInt64Value), typeof(UInt64ArrayValue), objectActivator));
            Map.Add(typeof(float), new MapTypes(typeof(SingleValue), typeof(SingleArrayValue), objectActivator));
            Map.Add(typeof(double), new MapTypes(typeof(DoubleValue), typeof(DoubleArrayValue), objectActivator));
            Map.Add(typeof(decimal), new MapTypes(typeof(DecimalValue), typeof(DecimalArrayValue), objectActivator));
            Map.Add(typeof(bool), new MapTypes(typeof(BooleanValue), typeof(BooleanArrayValue), objectActivator));
            Map.Add(typeof(string), new MapTypes(typeof(StringValue), typeof(StringArrayValue), t => null));
            Map.Add(typeof(DateTime), new MapTypes(typeof(DateTimeValue), typeof(DateTimeArrayValue), objectActivator));
        }

        public static IValue TypeToValue(Type type, Func<object[]> argumentProvider = null)
        {
            var valueTypes = Find(type);

            var arguments = argumentProvider == null ? new object[] { valueTypes.Activator(type), new ValueInfo(), null } : argumentProvider();

            return (IValue)Activator.CreateInstance(valueTypes.SingleValue, arguments);
        }

        public static IValue TypeToValue<T>(Func<object[]> argumentProvider = null)
        {
            return TypeToValue(typeof(T), argumentProvider);
        }

        public static IValue TypeToArrayValue(Type type, Func<object[]> argumentProvider = null)
        {
            var valueTypes = Find(type);

            var arguments = argumentProvider == null ? new object[] { null, new ValueInfo(), null, null } : argumentProvider();

            return (IValue)Activator.CreateInstance(valueTypes.ArrayValue, arguments);
        }

        public static IValue TypeToArrayValue<T>(Func<object[]> argumentProvider = null)
        {
            return TypeToArrayValue(typeof(T), argumentProvider);
        }

        private static MapTypes Find(Type type)
        {
            MapTypes valueTypes = null;

            if (!Map.TryGetValue(type, out valueTypes))
            {
                throw new ArgumentException($"Unsupported type \"{type}\".", nameof(type));
            }

            return valueTypes;
        }
    }
}
