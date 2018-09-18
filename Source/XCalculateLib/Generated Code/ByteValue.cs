namespace XCalculateLib
{
    public class ByteValue : BaseValue<byte>
    {
        public ByteValue(byte value, IValueInfo info = null, ValueValidator<byte> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

