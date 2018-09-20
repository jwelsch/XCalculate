namespace XCalculateLib
{
    public class UInt16ArrayValue : BaseArrayValue<ushort[]>
    {
        public UInt16ArrayValue(ushort[] value, IValueInfo info = null, ValueValidator<ushort[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

