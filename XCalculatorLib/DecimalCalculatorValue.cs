namespace XCalculatorLib
{
    public class DecimalCalculatorValue : BaseCalculatorValue<decimal>
    {
        public DecimalCalculatorValue(decimal value, DecimalCalculatorValueInfo info, ValueValidator<decimal> validator)
            : base(value, info, validator)
        {
        }
    }
}
