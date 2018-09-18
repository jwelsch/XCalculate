namespace XCalculateLib
{
    public class Int16ArrayValue : BaseArrayValue<short>
    {
        public Int16ArrayValue(short[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<short[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

