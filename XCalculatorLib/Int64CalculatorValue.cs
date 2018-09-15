namespace XCalculatorLib
{
    public class Int64CalculatorValue : BaseCalculatorValue<long>
    {
        public Int64CalculatorValue(long value, Int64CalculatorValueInfo info, ValueValidator<long> validator)
            : base(value, info, validator)
        {
        }
    }
}
