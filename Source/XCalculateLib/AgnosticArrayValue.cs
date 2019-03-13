using System;

namespace XCalculateLib
{
    public class AgnosticArrayValue : BaseArrayValue<Array>, IValue
    {
        object IValue.Value
        {
            get
            {
                return this.Value;
            }

            set
            {
                if (value != null && !value.GetType().IsArray)
                {
                    throw new ArgumentException("Assigned value must be an array type.");
                }

                this.Value = (Array)value;
            }
        }

        public AgnosticArrayValue(Array value, IValueInfo info = null, ValueValidator<Array> validator = null)
            : base(value, info, validator)
        {
        }

        public AgnosticArrayValue(IValueInfo info = null, ValueValidator<Array> validator = null)
            : this(null, info, validator)
        {
        }

        public TArray ToArray<TArray>()
        {
            return TypeConverter.ToArray<TArray>(this.Value);
        }
    }
}
