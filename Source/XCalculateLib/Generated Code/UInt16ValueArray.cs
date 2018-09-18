namespace XCalculateLib
{
    public class UInt16ArrayValue : BaseArrayValue<ushort>
    {
        public UInt16ArrayValue(ushort[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<ushort[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

