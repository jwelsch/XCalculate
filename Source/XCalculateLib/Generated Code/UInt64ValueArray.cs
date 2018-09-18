namespace XCalculateLib
{
    public class UInt64ArrayValue : BaseArrayValue<ulong>
    {
        public UInt64ArrayValue(ulong[] value, UInt64ArrayValueInfo info = null, Range lengthRange = null, ValueValidator<ulong[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

