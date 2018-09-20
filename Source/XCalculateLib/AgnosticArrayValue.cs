using System;

namespace XCalculateLib
{
    public class AgnosticArrayValue : BaseArrayValue<Array>, IValue
    {
        object IValue.Value
        {
            get { return this.Value; }
            set { this.Value = (Array)value; }
        }

        public override Type ValueType
        {
            get
            {
                if (this.Value == null)
                {
                    return null;
                }

                return this.Value.GetType();
            }
        }

        public AgnosticArrayValue(Array value, IValueInfo info = null, ValueValidator<Array> validator = null)
            : base(value, info, validator)
        {
        }

        public TArray ToArray<TArray>()
        {
            return TypeConverter.ToArray<TArray>(this.Value);
        }
    }
}
