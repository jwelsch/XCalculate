using System;

namespace XCalculateLib
{
    public class AgnosticArrayValue : ArrayValue<object>
    {
        public new Type ValueType
        {
            get;
            private set;
        }

        public AgnosticArrayValue(object[] value, Type type, IValueInfo info = null, Range lengthRange = null, ValueValidator<object[]> validator = null)
            : base(value, info, lengthRange, i =>
            {
                if (i.GetType() != type)
                {
                    throw new ArgumentException($"Expected the value to have type {type}, but it had type {i.GetType()} instead.");
                }
                return validator == null ? true : validator(i);
            })
        {
            this.ValueType = type;
        }
    }
}
