namespace XCalculatorLib
{
    public class DoubleArrayCalculatorValue : BaseArrayCalculatorValue<double>
    {
        public DoubleArrayCalculatorValue(double[] value, DoubleArrayCalculatorValueInfo info, Range lengthRange = null, ValueValidator<double[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}
