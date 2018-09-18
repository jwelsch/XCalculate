using System;

namespace XCalculateLib
{
    public class AgnosticValue : BaseValue<object>
    {
        public new Type ValueType
        {
            get;
            private set;
        }

        public AgnosticValue(object value, IValueInfo info = null, ValueValidator<object> validator = null)
            : base(value, info, i =>
            {
                if (i.GetType() != value.GetType())
                {
                    throw new ArgumentException($"Expected the value to have type {value.GetType()}, but it had type {i.GetType()} instead.");
                }
                return validator == null ? true : validator(i);
            })
        {
            this.ValueType = value.GetType();
        }
    }
}
