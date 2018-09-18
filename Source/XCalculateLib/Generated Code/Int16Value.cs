namespace XCalculateLib
{
    public class Int16Value : BaseValue<short>
    {
        public Int16Value(short value, Int16ValueInfo info = null, ValueValidator<short> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

