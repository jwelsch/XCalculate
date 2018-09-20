namespace XCalculateLib
{
    public class SingleArrayValue : BaseArrayValue<float[]>
    {
        public SingleArrayValue(float[] value, IValueInfo info = null, ValueValidator<float[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

