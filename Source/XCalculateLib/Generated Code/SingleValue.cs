namespace XCalculateLib
{
    public class SingleValue : BaseValue<float>
    {
        public SingleValue(float value, IValueInfo info = null, ValueValidator<float> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

