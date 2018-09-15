namespace XCalculatorLib
{
    public class UInt16ArrayValue : BaseArrayValue<ushort>
    {
        public UInt16ArrayValue(ushort[] value, UInt16ArrayValueInfo info = null, Range lengthRange = null, ValueValidator<ushort[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

