namespace XCalculateLib
{
    public class Int64Value : BaseValue<long>
    {
        public Int64Value(long value, Int64ValueInfo info = null, ValueValidator<long> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

