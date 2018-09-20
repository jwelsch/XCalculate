using System;
using System.Collections.Generic;

namespace XCalculateLib
{
    public static class TypeConverter
    {
        private static readonly Dictionary<Type, Func<object, object>> Map = new Dictionary<Type, Func<object, object>>();

        static TypeConverter()
        {
            Map.Add(typeof(byte), v => Convert.ToByte(v));
            Map.Add(typeof(sbyte), v => Convert.ToSByte(v));
            Map.Add(typeof(short), v => Convert.ToInt16(v));
            Map.Add(typeof(ushort), v => Convert.ToUInt16(v));
            Map.Add(typeof(int), v => Convert.ToInt32(v));
            Map.Add(typeof(uint), v => Convert.ToUInt32(v));
            Map.Add(typeof(long), v => Convert.ToInt64(v));
            Map.Add(typeof(ulong), v => Convert.ToUInt64(v));
            Map.Add(typeof(float), v => Convert.ToSingle(v));
            Map.Add(typeof(double), v => Convert.ToDouble(v));
            Map.Add(typeof(decimal), v => Convert.ToDecimal(v));
            Map.Add(typeof(bool), v => Convert.ToBoolean(v));
            Map.Add(typeof(string), v => Convert.ToString(v));
            Map.Add(typeof(DateTime), v => DateTime.Parse(v.ToString()));
        }

        public static object ToObject(object value, Type toType)
        {
            if (toType == null)
            {
                throw new ArgumentNullException(nameof(toType));
            }

            if (value != null && value.GetType() == toType)
            {
                return value;
            }

            Func<object, object> convertFunc = null;

            if (!Map.TryGetValue(toType, out convertFunc))
            {
                throw new ArgumentException($"The type to convert to, {toType}, is unsupported.", nameof(toType));
            }

            return convertFunc(value);
        }

        public static T ToObject<T>(object value)
        {
            return (T)ToObject(value, typeof(T));
        }

        public static object ToArray(Array value, Type toArrayType)
        {
            if (!toArrayType.IsArray)
            {
                throw new ArgumentException("Type specifier must be an array type.", nameof(toArrayType));
            }

            if (value == null)
            {
                return null;
            }

            if (toArrayType == value.GetType())
            {
                return value;
            }

            var elementType = toArrayType.GetElementType();

            var outArray = (Array)Activator.CreateInstance(toArrayType, value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                var o = ToObject(value.GetValue(i), elementType);

                outArray.SetValue(o, i);
            }

            return outArray;
        }

        public static TArray ToArray<TArray>(Array value)
        {
            return (TArray)ToArray(value, typeof(TArray));
        }

        /// <summary>
        /// Must cast to object first since the compiler won't allow a direct cast from Array to TArray.
        /// </summary>
        /// <typeparam name="TArray">Type of array to cast to.</typeparam>
        /// <param name="array">Array to cast.</param>
        /// <returns>Array of type TArray.</returns>
        private static TArray CastArray<TArray>(Array array)
        {
            var outArray = (object)array;

            return (TArray)outArray;
        }
    }
}
