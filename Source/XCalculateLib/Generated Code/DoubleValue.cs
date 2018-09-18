namespace XCalculateLib
{
    public class DoubleValue : BaseValue<double>
    {
        public DoubleValue(double value, DoubleValueInfo info = null, ValueValidator<double> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

