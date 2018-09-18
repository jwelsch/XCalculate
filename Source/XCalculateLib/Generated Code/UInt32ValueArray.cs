namespace XCalculateLib
{
    public class UInt32ArrayValue : BaseArrayValue<uint>
    {
        public UInt32ArrayValue(uint[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<uint[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

