namespace XCalculateLib
{
    public class SByteArrayValue : BaseArrayValue<sbyte[]>
    {
        public SByteArrayValue(sbyte[] value, IValueInfo info = null, ValueValidator<sbyte[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

