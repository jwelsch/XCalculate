namespace XCalculateLib
{
    public class SingleArrayValue : BaseArrayValue<float>
    {
        public SingleArrayValue(float[] value, SingleArrayValueInfo info = null, Range lengthRange = null, ValueValidator<float[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

