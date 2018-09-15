namespace XCalculatorLib
{
    public class ByteArrayValue : BaseArrayValue<byte>
    {
        public ByteArrayValue(byte[] value, ByteArrayValueInfo info = null, Range lengthRange = null, ValueValidator<byte[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

