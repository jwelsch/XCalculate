namespace XCalculatorLib
{
    public class DoubleArrayValue : BaseArrayValue<double>
    {
        public DoubleArrayValue(double[] value, DoubleArrayValueInfo info = null, Range lengthRange = null, ValueValidator<double[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

