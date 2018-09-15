namespace XCalculatorLib
{
    public class DecimalValue : BaseValue<decimal>
    {
        public DecimalValue(decimal value, DecimalValueInfo info = null, ValueValidator<decimal> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

