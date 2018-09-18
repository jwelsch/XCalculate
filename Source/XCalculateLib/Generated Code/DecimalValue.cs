namespace XCalculateLib
{
    public class DecimalValue : BaseValue<decimal>
    {
        public DecimalValue(decimal value, IValueInfo info = null, ValueValidator<decimal> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

