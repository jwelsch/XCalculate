namespace XCalculatorLib
{
    public class BooleanValue : BaseValue<bool>
    {
        public BooleanValue(bool value, BooleanValueInfo info = null, ValueValidator<bool> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

