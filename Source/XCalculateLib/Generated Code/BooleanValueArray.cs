namespace XCalculateLib
{
    public class BooleanArrayValue : BaseArrayValue<bool>
    {
        public BooleanArrayValue(bool[] value, BooleanArrayValueInfo info = null, Range lengthRange = null, ValueValidator<bool[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

