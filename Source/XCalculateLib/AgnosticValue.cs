using System;

namespace XCalculateLib
{
    public class AgnosticValue : BaseValue<object>, IValue
    {
        object IValue.Value
        {
            get { return this.Value; }
            set { this.Value = value; }
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

        public AgnosticValue(object value, IValueInfo info = null, ValueValidator<object> validator = null)
            : base(value, info, validator)
        {
        }
    }
}
