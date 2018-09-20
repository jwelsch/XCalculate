namespace XCalculateLib
{
    public class DoubleArrayValue : BaseArrayValue<double[]>
    {
        public DoubleArrayValue(double[] value, IValueInfo info = null, ValueValidator<double[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

