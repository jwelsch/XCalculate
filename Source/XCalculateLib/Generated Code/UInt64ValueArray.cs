namespace XCalculateLib
{
    public class UInt64ArrayValue : BaseArrayValue<ulong[]>
    {
        public UInt64ArrayValue(ulong[] value, IValueInfo info = null, ValueValidator<ulong[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

