namespace XCalculateLib
{
    public class DecimalArrayValue : BaseArrayValue<decimal[]>
    {
        public DecimalArrayValue(decimal[] value, IValueInfo info = null, ValueValidator<decimal[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

