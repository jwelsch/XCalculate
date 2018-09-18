namespace XCalculateLib
{
    public class ByteArrayValue : BaseArrayValue<byte>
    {
        public ByteArrayValue(byte[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<byte[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

