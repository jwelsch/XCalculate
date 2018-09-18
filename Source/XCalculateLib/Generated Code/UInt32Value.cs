namespace XCalculateLib
{
    public class UInt32Value : BaseValue<uint>
    {
        public UInt32Value(uint value, UInt32ValueInfo info = null, ValueValidator<uint> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

