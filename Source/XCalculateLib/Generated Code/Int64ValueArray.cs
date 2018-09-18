namespace XCalculateLib
{
    public class Int64ArrayValue : BaseArrayValue<long>
    {
        public Int64ArrayValue(long[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<long[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

