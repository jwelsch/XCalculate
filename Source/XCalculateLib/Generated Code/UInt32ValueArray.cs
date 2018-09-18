namespace XCalculateLib
{
    public class UInt32ArrayValue : BaseArrayValue<uint>
    {
        public UInt32ArrayValue(uint[] value, UInt32ArrayValueInfo info = null, Range lengthRange = null, ValueValidator<uint[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

