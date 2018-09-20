namespace XCalculateLib
{
    public class Int16ArrayValue : BaseArrayValue<short[]>
    {
        public Int16ArrayValue(short[] value, IValueInfo info = null, ValueValidator<short[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

