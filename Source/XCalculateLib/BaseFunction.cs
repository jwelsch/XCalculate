using System;

namespace XCalculateLib
{
    public abstract class BaseFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public abstract IValue[] Calculate(IValue[] inputs);

        protected static T GetValue<T>(IValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (typeof(T).IsArray || (value.Value != null && value.Value.GetType().IsArray))
            {
                throw new ArgumentException("Use BaseFunction.GetValues<T> for array types.");
            }

            return TypeConverter.ToObject<T>(value.Value);
        }

        protected static T GetValues<T>(IValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!typeof(T).IsArray && !value.Value.GetType().IsArray)
            {
                throw new ArgumentException("Use BaseFunction.GetValue<T> for non-array types.");
            }

            return TypeConverter.ToArray<T>((Array)value.Value);
        }
    }
}
