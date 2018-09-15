namespace XCalculatorLib
{
    public class DecimalArrayCalculatorValue : BaseArrayCalculatorValue<decimal>
    {
        public DecimalArrayCalculatorValue(decimal[] value, DecimalArrayCalculatorValueInfo info, Range lengthRange = null, ValueValidator<decimal[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}
