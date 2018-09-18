namespace XCalculateLib
{
    public class Int16Value : BaseValue<short>
    {
        public Int16Value(short value, IValueInfo info = null, ValueValidator<short> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

