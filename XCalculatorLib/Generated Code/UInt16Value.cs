namespace XCalculatorLib
{
    public class UInt16Value : BaseValue<ushort>
    {
        public UInt16Value(ushort value, UInt16ValueInfo info = null, ValueValidator<ushort> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

