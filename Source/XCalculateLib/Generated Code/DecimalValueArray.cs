namespace XCalculateLib
{
    public class DecimalArrayValue : BaseArrayValue<decimal>
    {
        public DecimalArrayValue(decimal[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<decimal[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

