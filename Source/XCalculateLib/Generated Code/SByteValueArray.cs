namespace XCalculateLib
{
    public class SByteArrayValue : BaseArrayValue<sbyte>
    {
        public SByteArrayValue(sbyte[] value, SByteArrayValueInfo info = null, Range lengthRange = null, ValueValidator<sbyte[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

