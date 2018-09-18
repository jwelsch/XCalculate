namespace XCalculateLib
{
    public class UInt32Value : BaseValue<uint>
    {
        public UInt32Value(uint value, IValueInfo info = null, ValueValidator<uint> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

