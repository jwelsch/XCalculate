namespace XCalculateLib
{
    public class UInt16Value : BaseValue<ushort>
    {
        public UInt16Value(ushort value, IValueInfo info = null, ValueValidator<ushort> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

