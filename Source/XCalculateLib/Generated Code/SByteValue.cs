namespace XCalculateLib
{
    public class SByteValue : BaseValue<sbyte>
    {
        public SByteValue(sbyte value, IValueInfo info = null, ValueValidator<sbyte> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

