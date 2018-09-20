namespace XCalculateLib
{
    public class ByteArrayValue : BaseArrayValue<byte[]>
    {
        public ByteArrayValue(byte[] value, IValueInfo info = null, ValueValidator<byte[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

