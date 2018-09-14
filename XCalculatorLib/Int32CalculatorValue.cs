namespace XCalculatorLib
{
    public class Int32CalculatorValue : BaseCalculatorValue<int>
    {
        public Int32CalculatorValue(int? value = null, Int32CalculatorValueInfo info = null, ValueValidator<int> validator = null)
            : base(value ?? 0, info, validator)
        {
        }
    }
}
