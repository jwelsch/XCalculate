namespace XCalculateLib
{
    public class DoubleValue : BaseValue<double>
    {
        public DoubleValue(double value, IValueInfo info = null, ValueValidator<double> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

