namespace XCalculateLib
{
    public class UInt32ArrayValue : BaseArrayValue<uint[]>
    {
        public UInt32ArrayValue(uint[] value, IValueInfo info = null, ValueValidator<uint[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

