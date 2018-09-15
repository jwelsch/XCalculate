namespace XCalculatorLib
{
    public class DecimalArrayValue : BaseArrayValue<decimal>
    {
        public DecimalArrayValue(decimal[] value, DecimalArrayValueInfo info = null, Range lengthRange = null, ValueValidator<decimal[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

