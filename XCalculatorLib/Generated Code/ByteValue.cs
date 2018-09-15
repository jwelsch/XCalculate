namespace XCalculatorLib
{
    public class ByteValue : BaseValue<byte>
    {
        public ByteValue(byte value, ByteValueInfo info = null, ValueValidator<byte> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

