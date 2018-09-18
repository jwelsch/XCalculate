namespace XCalculateLib
{
    public class UInt64Value : BaseValue<ulong>
    {
        public UInt64Value(ulong value, UInt64ValueInfo info = null, ValueValidator<ulong> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

