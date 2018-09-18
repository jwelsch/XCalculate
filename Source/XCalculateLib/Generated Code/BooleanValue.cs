namespace XCalculateLib
{
    public class BooleanValue : BaseValue<bool>
    {
        public BooleanValue(bool value, IValueInfo info = null, ValueValidator<bool> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

