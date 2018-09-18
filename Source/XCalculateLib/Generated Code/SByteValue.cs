namespace XCalculateLib
{
    public class SByteValue : BaseValue<sbyte>
    {
        public SByteValue(sbyte value, SByteValueInfo info = null, ValueValidator<sbyte> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

