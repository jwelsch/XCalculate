namespace XCalculateLib
{
    public class UInt64Value : BaseValue<ulong>
    {
        public UInt64Value(ulong value, IValueInfo info = null, ValueValidator<ulong> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

