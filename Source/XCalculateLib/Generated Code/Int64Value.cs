namespace XCalculateLib
{
    public class Int64Value : BaseValue<long>
    {
        public Int64Value(long value, IValueInfo info = null, ValueValidator<long> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

